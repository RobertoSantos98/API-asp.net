using API.Application.ViewModels;
using API.Domain.DTOs;

namespace API.Models
{
    public interface IAgendaRepository
    {
        Task<ResponseModel<List<AgendaDTO>>> ListarAgenda();
        Task<ResponseModel<List<Agenda>>> ListarAgendaPorDia(DateOnly data);
        Task<ResponseModel<Agenda>> MarcarConsulta(AgendaViewModel agenda);
        //Task<ResponseModel<List<object>>> ListarTodaAgenda();
    }
}
