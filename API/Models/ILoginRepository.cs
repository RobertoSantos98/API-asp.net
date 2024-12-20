using API.Application.ViewModels;

namespace API.Models
{
    public interface ILoginRepository
    {
        public Task<ResponseModel<Login>> CriarLogin(Login login, string cpf);
        public Task<ResponseModel<Login>> Editar();
        public Task<ResponseModel<Login>> Remover();
        public Task<ResponseModel<Login>> Logar(AuthViewModel auth);
    }
}
