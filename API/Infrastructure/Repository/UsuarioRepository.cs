using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();


        
        public async Task<ResponseModel<Usuario>> Add(Usuario usuario)
        {
            ResponseModel<Usuario> resposta = new();

            try
            {
                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                resposta.Dados = usuario;
                resposta.Mensagem = "O usuario foi adicionado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<Usuario>>> EncontrarPorNome(string nome)
        {
            ResponseModel<List<Usuario>> resposta = new();

            try
            {
                var dados = await _context.Usuarios.Where(u => u.nomecompleto.StartsWith(nome)).ToListAsync();

                if(dados != null){
                    resposta.Dados = dados;
                    resposta.Mensagem = "Os usuarios foram coletados!";
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "Nenhum usuario encontrado!";
                    return resposta;
                }

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<Usuario>> FindById(int id)
        {
            ResponseModel<Usuario> resposta = new();

            try
            {
                var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.id == id);

                if (dados != null)
                {
                    resposta.Dados = dados;
                    resposta.Mensagem = "O usuário foi encontrado!";
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "O usuário não foi encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            
        }

        public async Task<ResponseModel<List<Usuario>>> ListarUsuarios()
        {
            ResponseModel<List<Usuario>> resposta = new();

            try
            {
                var dados = await _context.Usuarios.ToListAsync();
                resposta.Dados = dados;
                resposta.Mensagem = "Todos os dados foram coletados!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<Usuario>> Remover(int id)
        {
            ResponseModel<Usuario> resposta = new();

            try
            {
                var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.id == id);
                if(dados != null){
                    _context.Usuarios.Remove(dados);
                    await _context.SaveChangesAsync();

                    resposta.Dados = dados;
                    resposta.Mensagem = "O seguinte usuário foi removido!";
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "O usuário não foi encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<Usuario>> BuscarCpf(string cpf)
        {
            ResponseModel<Usuario> resposta = new();

            try
            {
                var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.cpf == cpf);
                if (dados != null)
                {
                    resposta.Dados = dados;
                    resposta.Mensagem = "O usuário foi encontrado no bando de dados!";
                    return resposta;
                }

                resposta.Mensagem = "O CPF não costa no nosso banco de dados!";
                resposta.Status = false;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }

        }
    }
}
