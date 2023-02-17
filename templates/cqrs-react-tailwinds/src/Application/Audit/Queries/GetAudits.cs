// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using Application.Core;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;
// using Infrastructure.Extension;
// using X.PagedList;

// namespace Application.Audit.Queries
// {
//     public class GetAudits
//     {
//         public class Query : IRequest<FetchData<Domain.Audit>>
//         {
//             public int Page { get; set; }

//             public bool Descending { get; set; }
//             public string SortBy { get; set; }
//             public string Search { get; set; }

//             public int Size { get; set; }

//         }

//         public class Handler : IRequestHandler<Query, FetchData<Domain.Audit>>
//         {
//             private readonly CanteenSystemContext _context;
//             public Handler(CanteenSystemContext context)
//             {
//                 _context = context;
//             }

//             public async Task<FetchData<Domain.Audit>> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 var items = await _context.AuditLogs.Where(x => x.Type != "None").ToListAsync(cancellationToken);

//                 if (!String.IsNullOrEmpty(request.Search))
//                 {
//                     items = items.FindAll(request.Search).ToList();
//                 }

//                 if (!String.IsNullOrEmpty(request.SortBy))
//                 {
//                     items = request.Descending ? items.OrderByDescending(request.SortBy).ToList() : items.OrderBy(request.SortBy).ToList();
//                 }

//                 if (request.Page <= 0) request.Page = 1; // make sure request.Page is  > 0
//                 if (request.Size <= 0) request.Size = items.Count > 0 ? items.Count : 10; // retrieve all if invalid request.Size

//                 return new FetchData<Domain.Audit>(items.ToPagedList<Domain.Audit>(request.Page, request.Size).ToList(), items.Count);
//             }
//         }
//     }
// }