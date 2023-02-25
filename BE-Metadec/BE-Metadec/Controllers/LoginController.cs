using BE_Metadec.Domain.IServices;
using BE_Metadec.Domain.Models;
using BE_Metadec.DTO;
using BE_Metadec.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BE_Metadec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;

        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            try
            {
                var password = Encriptar.EncriptarPassword(login.password);
                var user = await _loginService.ValidateUser(login.usuario,password);
                if (user == null)
                {
                    return BadRequest(new { message = "Datos incorrectos" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new {token = tokenString});
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
    }
}
