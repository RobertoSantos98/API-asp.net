using API.Application.ViewModels;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("agenda")]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepository _repository;

        public AgendaController(IAgendaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> ListarAgenda()
        {
            var response = await _repository.ListarAgenda();
            return Ok(response);
        }

        [HttpGet("{data}")]
        public async Task<IActionResult> ListarAgendaPorData(DateOnly data)
        {
            var response = await _repository.ListarAgendaPorDia(data);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> MarcarConsulta(AgendaViewModel agenda)
        {
            var response = await _repository.MarcarConsulta(agenda);
            return Ok(response);
        }
    }
}
