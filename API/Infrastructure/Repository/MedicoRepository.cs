using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class MedicoRepository : IMedicoInterface
    {

        public readonly ConnectionContext _context = new ConnectionContext();



        public async Task<ResponseModel<Medico>> Add(Medico medico)
        {
            ResponseModel<Medico> resposta = new ResponseModel<Medico>();

            try
            {
                await _context.Medicos.AddAsync(medico);
                await _context.SaveChangesAsync();
                resposta.Dados = medico;
                resposta.Mensagem = "O usuário foi salvo com sucesso!";
                return resposta;

            }
            catch (Exception e)
            {
                resposta.Dados = medico;
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<Medico>> FindById(int id)
        {
            ResponseModel<Medico> resposta = new ResponseModel<Medico>();

            try
            {
                var response = await _context.Medicos.FirstOrDefaultAsync(m => m.id == id);
                if (response != null)
                {
                    resposta.Dados = response;
                    resposta.Mensagem = "O médico foi encontrado!";
                    return resposta;
                }
                else
                {
                    resposta.Mensagem = "O Médico não foi encontrado!";
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

        public async Task<ResponseModel<List<Medico>>> ListarMedicos()
        {
            ResponseModel<List<Medico>> resposta = new ResponseModel<List<Medico>>();

            try
            {
                var medicos = await _context.Medicos.ToListAsync();
                resposta.Dados = medicos;
                resposta.Mensagem = "Os dados foram coletados com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<Medico>> Remover(Medico medico)
        {
            throw new NotImplementedException();
        }
    }
}
