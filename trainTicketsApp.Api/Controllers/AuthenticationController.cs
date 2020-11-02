using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using trainTicketsApp.Api.DTO;

namespace trainTicketsApp.Api.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class AuthenticationController : ControllerBase
        {
            private readonly IAuthenticationService _authenticationService;

            public AuthenticationController(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            [AllowAnonymous]
            [HttpPost]
            public async Task<ActionResult> RegisterUserAsync(PersonCreateDto userDto)
            {
                var user = await _authenticationService.RegisterUserAsync(userDto.Login, userDto.Password,userDto.Email);

                return Ok();
            }
        
        }
}
