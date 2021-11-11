using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application.Handlers;
using CovTestMgmt.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovTestMgmt.API.Controllers
{

    [ApiVersion("1.0")]
    public class HelloController : ApiControllerBase
    {
        public readonly ILogger<HelloController> _logger;
        public readonly IMediator _mediator;
        public HelloController(ILogger<HelloController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetHelloWorld()
        {
            Request.Headers.TryGetValue("X-Correlation-ID", out var correlationId);
            return Ok(await Task.FromResult("Hello World"));
        }
        // [HttpGet]
        // public async Task<GetHello.Response> GetHelloWorld()
        // {
        //     return await _mediator.Send(new GetHello.Query());
        // }

        [HttpGet]
        [ApiVersion("2.0")]
        public async Task<GetHelloQueryResponse> GetHelloWorld2([FromQuery] GetHelloQuery query)
        {
            return await _mediator.Send(query);
        }
    }

}