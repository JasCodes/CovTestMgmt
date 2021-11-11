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
        public async Task<LoginOrCreateNewUserCommandResponse> LoginOrCreateNewUser([FromQuery] LoginOrCreateNewUserCommand request)
        {
            return await _mediator.Send(request);
        }
    }

}