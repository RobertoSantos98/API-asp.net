using API.Application.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuario;

        public UsuarioController(IUsuarioRepository usuario)
        {
            _usuario = usuario;
        }

        [HttpPost]
        public async Task<IActionResult> add(UsuarioViewModel usuario)
        {
            var novoUsuario = new Usuario(usuario.nomecompleto, usuario.cpf, usuario.datanascimento);
            var response = await _usuario.Add(novoUsuario);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var response = await _usuario.ListarUsuarios();
            return Ok(response);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Encontrar(int id)
        {
            var response = await _usuario.FindById(id);
            return Ok(response);
        }

        [HttpGet("procurar")]
        public async Task<IActionResult> Procurar(string nome)
        {
            var response = await _usuario.EncontrarPorNome(nome);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _usuario.Remover(id);
            return Ok(response);
        }

    }
}
