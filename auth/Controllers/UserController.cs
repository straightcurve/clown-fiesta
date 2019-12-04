using auth.Models;
using auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers {

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {
        private IUserService m_userService;

        public UserController(IUserService userService) {
            m_userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationDto dto) {
            var user = m_userService.Authenticate(dto.Username, dto.Password);

            if(user == null)
                return BadRequest(new { message = "Incorrect credentials." });
            
            return Ok(user);
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult Get(string id) {
            return Ok(m_userService.Get(id));
        }
    }
}