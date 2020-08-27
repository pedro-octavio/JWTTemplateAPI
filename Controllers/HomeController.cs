using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTTemplateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Authorize")]
        [Authorize]
        public IActionResult Authorize()
        {
            return Ok("Hello World, but authenticated!");
        }

        [HttpGet]
        [Route("Anonymous")]
        [AllowAnonymous]
        public IActionResult Anonymous()
        {
            return Ok("Hello World, but not authenticated!");
        }
    }
}
