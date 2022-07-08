using AdminMicroServices.Interface;
using AdminMicroServices.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
      
        private readonly IJWTMangerRepository iJWTMangerRepository;
        public LoginController( IJWTMangerRepository _iJWTMangerRepository)
        {
           
            iJWTMangerRepository = _iJWTMangerRepository;
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel loginViewModel)
        {

            var token = iJWTMangerRepository.Authenticate(loginViewModel);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}
