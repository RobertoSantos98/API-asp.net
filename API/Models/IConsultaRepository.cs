using API.Application.ViewModels;

namespace API.Models
{
    public interface IConsultaRepository
    {
        public Task<ResponseModel<Consulta>> CriarConsulta(ConsultaViewModel consulta);
        public Task<ResponseModel<Consulta>> Editar();
        public Task<ResponseModel<Consulta>> Remover();
        public Task<ResponseModel<List<Consulta>>> ListarConsultas();
        public Task<ResponseModel<List<object>>> ListarPorId(int id);
        public Task<ResponseModel<List<Consulta>>> ListarPorMedico(int medico);
    }
}
