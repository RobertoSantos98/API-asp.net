using API.Infrastructure;

namespace API.Models
{
    public interface IMedicoInterface
    {
        public Task<ResponseModel<List<Medico>>> ListarMedicos();

        public Task<ResponseModel<Medico>> Add(Medico medico);

        public Task<ResponseModel<Medico>> FindById(int id);

        public Task<ResponseModel<Medico>> Remover(int id);

        public Task<ResponseModel<List<Medico>>> EncontrarPorNome(string nome);
    }
}
