using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebUI.DTOs;
using WebUI.Services;
using Domain.Security;
using Persistence;
using Infrastructure.Extension;
using X.PagedList;
using Application.Core;
using WebUI.Controllers;

namespace API.Controllers
{

    public class AccountsController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        public SignInManager<AppUser> _signInManager { get; }
        private readonly CanteenSystemContext _context;
        private readonly TokenService _tokenService;
        public AccountsController(UserManager<AppUser> userManger
                , SignInManager<AppUser> signInManager
                , CanteenSystemContext context
                , TokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManger;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

            if (result.Succeeded)
            {
                return await CreateUserObjectAsync(user);
            }

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO registerDTO)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == registerDTO.Email))
            {
                ModelState.AddModelError("email", "Email taken");
                return ValidationProblem(ModelState);
            }

            if (await _userManager.Users.AnyAsync(x => x.UserName == registerDTO.Username))
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem(ModelState);
            }

            var user = new AppUser
            {
                DisplayName = registerDTO.DisplayName,
                Email = registerDTO.Email,
                UserName = registerDTO.Username
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            await _userManager.AddToRoleAsync(user, UserRoles.Admin);

            if (result.Succeeded)
            {
                return await CreateUserObjectAsync(user);
            }

            return BadRequest("Problem registering user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return await CreateUserObjectAsync(user);
        }
        [Authorize(Permissions.Users.ChangeRole)]
        [HttpPatch("edit-user-roles/{id}")]
        public async Task<ActionResult<List<IdentityRole>>> EditUserRole(string id, EditUserRoleDTO dto)
        {
            if (!(dto.RolesToBeAdded.Any() || dto.RolesToBeRemoved.Any()))
            {
                return BadRequest("There is no role to be added or removed.");
            }

            if (dto.RolesToBeAdded.Intersect(dto.RolesToBeRemoved).Any())
            {
                return BadRequest("A same role exists in both arrays.");
            }

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return BadRequest("user does not exist.");
            }

            var roles = from ur in _context.UserRoles
                        where ur.UserId == id
                        join r in _context.Roles on ur.RoleId equals r.Id
                        select r;
            foreach (var role in dto.RolesToBeAdded)
            {
                if (!roles.Any(x => x.Id == role.Id) && _context.Roles.Any(x => x.Id == role.Id))
                    await _userManager.AddToRoleAsync(user, role.Name);
            }
            foreach (var role in dto.RolesToBeRemoved)
            {
                if (roles.Any(x => x.Id == role.Id))
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
            }
            return Ok();
        }
        [Authorize(Permissions.Users.ViewOther)]
        [HttpGet("get-user/{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            return await CreateUserObjectAsync(user);
        }
        [Authorize(Permissions.Users.List)]
        [HttpGet("get-all")]
        public async Task<ActionResult<FetchData<UserDTO>>> GetAllUser([FromQuery] string search, [FromQuery] string sortBy, [FromQuery] bool descending, [FromQuery] int page, [FromQuery] int size = -1)
        {
            var users = await _userManager.Users.ToListAsync();
            List<UserDTO> dTOs = new List<UserDTO>();

            foreach (var u in users)
            {
                dTOs.Add(await CreateUserObjectAsync(u));
            }

            if (!String.IsNullOrEmpty(search))
            {
                dTOs = dTOs.FindAll(search).ToList();
            }

            if (!String.IsNullOrEmpty(sortBy))
            {
                dTOs = descending ? dTOs.OrderByDescending(sortBy).ToList() : dTOs.OrderBy(sortBy).ToList();
            }

            if (page <= 0) page = 1; // make sure page is  > 0
            if (size <= 0) size = dTOs.Count > 0 ? dTOs.Count : 10; // retrieve all if invalid size

            var paginated = dTOs.ToPagedList<UserDTO>(page, size).ToList();

            return new FetchData<UserDTO>(paginated, dTOs.Count);
        }

        private async Task<UserDTO> CreateUserObjectAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            return new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Locked = user.LockoutEnabled && user.LockoutEnd > DateTime.Now,
                DisplayName = user.DisplayName,
                Image = null,
                Token = await _tokenService.CreateTokenAsync(user),
                Username = user.UserName,
                Roles = roles.ToList(),
            };
        }
    }
}