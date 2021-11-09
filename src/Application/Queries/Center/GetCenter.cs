// using System;
// using System.Collections.Generic;
// using System.ComponentModel;
// using System.Linq;
// using System.Threading;
// using System.Threading.Tasks;
// using CovTestMgmt.Domain.Entities;
// using MediatR;

// namespace CovTestMgmt.Application.Queries
// {
//     public static class GetCenter
//     {
//         // public class Response
//         // {
//         //     [DefaultValue("World")]
//         //     public string name { get; init; }
//         // }
//         public class Query : IRequest<Center>
//         {
//             public Guid Id { get; init; }
//         }

//         public class Handler : IRequestHandler<Query, Center>
//         {
//             // private readonly IRepository _repository;

//             // public Handler(IRepository repository)
//             // {
//             //     // _repository = repository;
//             // }

//             public async Task<Center> Handle(Query request, CancellationToken cancellationToken)
//             {
//                 // return await _repository.GetCenter(request.Id);
//             }

//         }

//     }
// }