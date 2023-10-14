using HMS_Web_APIs.Features.Login.Command;
using HMS_Web_APIs.Models;
using HMS_Web_APIs.Models.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HMS_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IMediator _Mediator;
        protected IMediator Mediator => _Mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public IConfiguration _config;

        public AuthenticationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost(nameof(AuthLogin))]
        public async Task<IActionResult> AuthLogin(LoginModelCommand login)
        {
            return Ok(await Mediator.Send(login));
        }
    }
}
