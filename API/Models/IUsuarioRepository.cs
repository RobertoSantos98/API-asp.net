namespace API.Models
{
    public interface IUsuarioRepository
    {
        public Task<ResponseModel<List<Usuario>>> ListarUsuarios();

        public Task<ResponseModel<Usuario>> Add(Usuario usuario);

        public Task<ResponseModel<Usuario>> FindById(int id);

        public Task<ResponseModel<Usuario>> Remover(int id);

        public Task<ResponseModel<List<Usuario>>> EncontrarPorNome(string nome);
    }
}
