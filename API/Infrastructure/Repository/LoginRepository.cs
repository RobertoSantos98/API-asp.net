using API.Application.Services;
using API.Application.ViewModels;
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
                    resposta.Status = false;
                    return resposta;
                }
            }
            catch (Exception ex)
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

        public async Task<ResponseModel<Login>> Logar(AuthViewModel auth)
        {
            ResponseModel<Login> resposta = new ResponseModel<Login>();

            var Login = new Login(auth.usuario, auth.password);

            try
            {
                var dados = await _context.Login.FirstOrDefaultAsync(l => l.login == auth.usuario);

                if (dados == null)
                {
                    resposta.Mensagem = "Não foi possivel encontrar usuário no sistema!";
                }

                if (auth.password == dados.password)
                {
                    var token = TokenServices.GenerateToken(new Login());
                    resposta.Dados = dados;

                    resposta.Mensagem = token.ToString();
                     
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "A senha não corresponde com o usuario informado!";
                    resposta.Status = false;
                    return resposta;
                }

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.InnerException?.Message ?? ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
    }
}
