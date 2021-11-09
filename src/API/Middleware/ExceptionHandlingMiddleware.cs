// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Net;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;

// namespace CovTestMgmt.API.Middleware
// {
//     class a : IActionResult
//     {
//         public Task ExecuteResultAsync(ActionContext context)
//         {
//             throw new NotImplementedException();
//         }
//     }
//     public class ExceptionHandlingMiddleware : IMiddleware
//     {
//         public async Task InvokeAsync(HttpContext context, RequestDelegate next)
//         {
//             try
//             {
//                 await next(context);
//             }
//             catch (Exception ex)
//             {
//                 // ProblemDetails problemDetails = new ProblemDetails
//                 // {
//                 //     Title = "An error occurred",
//                 //     Detail = ex.Message,
//                 //     Status = StatusCodes.Status500InternalServerError,
//                 //     Instance = context.Request.Path.Value
//                 // };
//                 // var a = new ExceptionResult();
//                 context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//                 context.Response.ContentType = "application/json";
//                 var content = new ObjectResult(null)
//                 {
//                     StatusCode = (int)HttpStatusCode.InternalServerError
//                 }.ToString();

//                 await context.Response.WriteAsync(content);

//             }
//         }


//     }
// }