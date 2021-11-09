using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovTestMgmt.API.Controllers
{

    // public class ErrorController : ApiControllerBase
    // {
    //     public readonly ILogger<HelloController> _logger;
    //     public readonly IMediator _mediator;
    //     public ErrorController(ILogger<HelloController> logger, IMediator mediator)
    //     {
    //         _logger = logger;
    //         _mediator = mediator;
    //     }

    //     [HttpGet]
    //     [Route("/error")]
    //     public async Task<IActionResult> GetError([FromQuery] GetError.Request request)
    //     {
    //         var result = await _mediator.Send(request);
    //         return Ok(result);
    //     }
    // }

    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        // [HttpGet]
        [Route("/error-local-development")]

        public IActionResult ErrorLocalDevelopment(
            [FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(
                detail: context.Error.StackTrace,
                title: context.Error.Message);
        }

        // [HttpGet]
        [Route("/error")]
        public IActionResult Error() => Problem();
    }

}