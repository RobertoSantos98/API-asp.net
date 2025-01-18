using API.Application.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [Route("api/consulta")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaRepository _consulta;

        public ConsultaController(IConsultaRepository consulta)
        {
            _consulta = consulta;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ListarConsultas()
        {
            var response = await _consulta.ListarConsultas();
            return Ok(response);
        }


        [HttpGet("paciente/{id}")]
        public async Task<IActionResult> ListarPorId(int id)
        {
            var response = await _consulta.ListarPorId(id);
            return Ok(response);
        }

        [HttpGet("medico/{id}")]
        public async Task<IActionResult> ListarPorMedico(int id)
        {
            var response = await _consulta.ListarPorMedico(id);
            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CriarConsulta(ConsultaViewModel consulta)
        {
            var response = await _consulta.CriarConsulta(consulta);
            return Ok(response);
        }
    }
}
