using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ConnectionContext _context = new();

        public async Task<ResponseModel<Login>> CriarLogin(Login login, string cpf)
        {
            ResponseModel<Login> resposta = new();

            try
            {

                var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.cpf == cpf);

                if (usuario != null)
                {

                    Login loginNovo = new(login.login, login.password, usuario.id);

                    await _context.Login.AddAsync(loginNovo);
                    await _context.SaveChangesAsync();

                    resposta.Dados = loginNovo;
                    resposta.Mensagem = "O login foi criado com sucesso anexado ao usuário: " + usuario.nomecompleto;
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Não foi possivel encontrar esse usuário no nosso sistema!";
                    return resposta;
                }
            }
            catch (DbUpdateException ex)
            {
                resposta.Mensagem = ex.InnerException?.Message ?? ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<Login>> Editar()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<Login>> Remover()
        {
            throw new NotImplementedException();
        }
    }
}
