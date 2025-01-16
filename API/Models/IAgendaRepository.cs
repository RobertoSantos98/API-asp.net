using API.Application.ViewModels;

namespace API.Models
{
    public interface IAgendaRepository
    {
        Task<ResponseModel<List<object>>> ListarAgenda();
        Task<ResponseModel<List<Agenda>>> ListarAgendaPorDia(DateOnly data);
        Task<ResponseModel<Agenda>> MarcarConsulta(AgendaViewModel agenda);
    }
}
