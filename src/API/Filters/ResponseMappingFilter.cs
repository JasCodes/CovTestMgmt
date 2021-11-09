// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net;
// using System.Threading.Tasks;
// using CovTestMgmt.Domain.Entities;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Filters;

// namespace CovTestMgmt.API.Filters
// {

//     public class ResponseMappingFilter : IActionFilter
//     {
//         public void OnActionExecuted(ActionExecutedContext context)
//         {
//             if (context.Result is ObjectResult objectResult && objectResult.Value is IHttpResponse httpResponse && httpResponse.StatusCode != HttpStatusCode.OK)
//                 context.Result = new ObjectResult(httpResponse) { StatusCode = (int)httpResponse.StatusCode };
//         }

//         public void OnActionExecuting(ActionExecutingContext context)
//         {
//         }
//     }
// }