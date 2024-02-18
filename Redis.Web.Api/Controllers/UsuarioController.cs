using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redis.Business.Auth;
using Redis.Business.Models;
using Redis.Infra.Interface;

namespace Redis.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController(IUsuarioService usuarioService) : ControllerBase
    {
        private readonly IUsuarioService _usuarioService = usuarioService;

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(TokenService service, string name)
        {
            Usuario? userLogged = await _usuarioService.Login(name);

            if (userLogged == null) return NotFound(new { message = "user not found."});

            return Ok(service.Generate(userLogged));
        }
    }
}
