using JWTTemplateAPI.Models;
using JWTTemplateAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace JWTTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            try
            {
                var token = TokenService.GenerateToken(user);

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
