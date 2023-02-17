using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Domain;
using Domain.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using WebUI.DTOs;

namespace WebUI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SignInManager<AppUser> _signInManager { get; }
        private readonly CanteenSystemContext _context;
        public RolesController(CanteenSystemContext context, UserManager<AppUser> userManger, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManger = userManger;
        }

        [HttpGet]
        [Authorize(Permissions.Role.List)]
        public async Task<ActionResult<List<IdentityRole>>> GetRoles()
        {
            List<RoleDTO> dTOs = new List<RoleDTO>();
            var roles = _roleManager.Roles.ToList();

            foreach (var r in roles)
            {
                var claims = await _roleManager.GetClaimsAsync(r);
                dTOs.Add(new RoleDTO { Id = r.Id, Name = r.Name, ClaimDescription = String.Join(",", claims.Select(x => x.Value)) });
            }
            return Ok(dTOs);
        }
        [HttpGet("get-role/{roleName}")]
        [Authorize(Permissions.Role.View)]
        public async Task<ActionResult<IdentityRole>> GetRole(string roleName)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Name == roleName);
            if (role == null)
            {
                return BadRequest("role does not exist");
            }
            var claims = await _roleManager.GetClaimsAsync(role);
            RoleDTO dTOs = new RoleDTO { Id = role.Id, Name = role.Name, ClaimDescription = String.Join(",", claims.Select(x => x.Value)) };

            return Ok(dTOs);
        }
        [HttpGet("get-claims")]
        [Authorize(Permissions.Role.ViewRoleClaim)]
        public ActionResult<List<IdentityRole>> GetClaims()
        {
            var claims = _context.RoleClaims.ToList();
            var dto = claims.Select(c => new ClaimDTO { Type = c.ClaimType, Value = c.ClaimValue }).GroupBy(x => x.Value).Select(g => g.First()).ToList();
            return Ok(dto);
        }
        [HttpGet("get-claims/{roleName}")]
        [Authorize(Permissions.Role.ListClaims)]
        public async Task<ActionResult<List<ClaimDTO>>> GetUserRoleAndClaims(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return BadRequest("role does not exist");
            }
            var claims = await _roleManager.GetClaimsAsync(role);
            return Ok(claims.Select(c => new ClaimDTO { Type = c.Type, Value = c.Value }).ToList());
        }

        [HttpPost("add-role/{roleName}")]
        [Authorize(Permissions.Role.AddClaimToRole)]
        public async Task<ActionResult<List<IdentityRole>>> AddRole(string roleName,AddRemoveClaimDTO dto)
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
            var newRole = await _roleManager.FindByNameAsync(roleName);

            foreach (var roleClaim in dto.ClaimsToBeAdded)
            {
                await _roleManager.AddClaimAsync(newRole, new Claim(roleClaim.Type, roleClaim.Value));
            }

            return Ok();
        }
        [HttpPatch("edit-role/{roleName}")]
        [Authorize(Permissions.Role.AddClaimToRole)]
        public async Task<ActionResult<List<IdentityRole>>> EditRole(string roleName, AddRemoveClaimDTO dto)
        {
            var role = await _roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return BadRequest("role does not exist");
            }
            var claims = await _roleManager.GetClaimsAsync(role);
            foreach (var roleClaim in dto.ClaimsToBeAdded)
            {
                if (!claims.Any(x => x.Value == roleClaim.Value))
                    await _roleManager.AddClaimAsync(role, new Claim(roleClaim.Type, roleClaim.Value));
            }
            foreach (var roleClaim in dto.ClaimsToBeRemoved)
            {
                if (claims.Any(x => x.Value == roleClaim.Value))
                    await _roleManager.RemoveClaimAsync(role, new Claim(roleClaim.Type, roleClaim.Value));
            }
            return Ok();
        }
        private ClaimDTO GetClaimDTO(Claim claim)
        {
            return new ClaimDTO { Type = claim.Type, Value = claim.Value };
        }


    }
}