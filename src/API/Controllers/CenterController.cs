using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovTestMgmt.Application.Commands;
using CovTestMgmt.Application.Queries;
using CovTestMgmt.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovTestMgmt.API.Controllers
{

    [ApiVersion("1.0")]
    public class CenterController : ApiControllerBase
    {
        public readonly ILogger<HelloController> _logger;
        public readonly IMediator _mediator;
        public CenterController(ILogger<HelloController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CreateCenter([FromQuery] CreateCenter.Query query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}