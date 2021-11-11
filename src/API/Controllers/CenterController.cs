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
    /// <summary>
    /// Controller for Center
    /// </summary>
    /// 
    [ApiVersion("1.0")]
    public class CenterController : ApiControllerBase
    {
        /// <summary>
        /// Inject logger for CenterController
        /// </summary>
        public readonly ILogger<HelloController> _logger;
        /// <summary>
        /// Inject Mediator for CenterController
        /// </summary>
        public readonly IMediator _mediator;

        /// <summary>
        /// Constructor for CenterController
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        public CenterController(ILogger<HelloController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        /// <summary>
        /// List all centers
        /// </summary>
        /// 
        /// <response code="400">Bad Request</response>
        /// <response code="401">Requires Authentication</response>
        /// <response code="403">Forbidden</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Internal Server Error</response>
        [HttpGet]
        [Route("list")]
        public async Task<ListCentersResponse> ListCenters([FromQuery] ListCentersQuery query)
        {
            return await _mediator.Send(query);

        }
        /// <summary>
        /// Create a new Center
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateCenter([FromQuery] CreateCenterCommand query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }

}

