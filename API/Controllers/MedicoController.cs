using API.Application.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/medico")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private readonly IMedicoInterface _medicoInterface;

        public MedicoController(IMedicoInterface medicoInterface)
        {
            _medicoInterface = medicoInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarMedicos()
        {
            var response = await _medicoInterface.ListarMedicos();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add(MedicoViewModel medicoView)
        {
            var novoMedico = new Medico(medicoView.NomeCompleto, medicoView.Especialidade);
            var response = await _medicoInterface.Add(novoMedico);
            return Ok(response);
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> Find(int id)
        {
            var response = await _medicoInterface.FindById(id);
            return Ok(response);
        }

    }
}
