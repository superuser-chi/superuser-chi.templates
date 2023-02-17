// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Application.Audit.Queries;
// using Application.Core;
// using Domain.Security;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using WebUI.DTOs;

// namespace WebUI.Controllers
// {
//     public class AuditLogsController : BaseApiController
//     {
//         [HttpGet]
//         [Authorize(Permissions.Audit.View)]
//         public virtual async Task<ActionResult<FetchData<AuditDTO>>> GetItems([FromQuery] string search, [FromQuery] string sortBy, [FromQuery] bool descending, [FromQuery] int page, [FromQuery] int size = -1)
//         {
//             var audits = await Mediator.Send(new GetAudits.Query { Search = search, SortBy = sortBy, Descending = descending, Page = page, Size = size });
//             return Ok(new FetchData<AuditDTO>(Mapper.Map<IEnumerable<AuditDTO>>(audits.Rows), audits.RowCount));
//         }
//     }
// }