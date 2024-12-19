using API.Application.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario(LoginViewModel login)
        {
            Login novoLogin = new(login.usuario, login.password);
            var response = await _repository.CriarLogin(novoLogin, login.cpf);
            return Ok(response);

        }



    }
}
