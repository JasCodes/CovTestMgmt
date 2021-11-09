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
    public class LoginController : ApiControllerBase
    {
        public readonly ILogger<LoginController> _logger;
        public readonly IMediator _mediator;
        public LoginController(ILogger<LoginController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        // [ProducesResponseType(typeof(LoginOrCreateNewUser.Response), 200)]

        public async Task<LoginOrCreateNewUserResponse> LoginOrCreateNewUser([FromQuery] LoginOrCreateNewUserRequest request)
        {
            return await _mediator.Send(request);
        }
        // [HttpPost]
        // public async Task<IActionResult> LoginOrCreateNewUser([FromQuery] LoginOrCreateNewUser.Request request)
        // {
        //     var result = await _mediator.Send(request);
        //     return Ok(result);
        // }
    }

}