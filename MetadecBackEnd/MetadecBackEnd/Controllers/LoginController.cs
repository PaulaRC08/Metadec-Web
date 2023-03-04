using MetadecBackEnd.Domain.IRepository;
using MetadecBackEnd.DTO;
using MetadecBackEnd.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetadecBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _config;

        public LoginController(ILoginRepository loginRepository, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginDTO login)
        {
            try
            {
                var password = Encriptar.EncriptarPassword(login.password);
                var user = await _loginRepository.ValidateUser(login.usuario, password);
                if (user == null)
                {
                    return BadRequest(new { message = "Datos incorrectos" });
                }
                string tokenString = JwtConfigurator.GetToken(user, _config);
                return Ok(new { token = tokenString });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

    }
}
