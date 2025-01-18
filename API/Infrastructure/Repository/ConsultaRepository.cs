using API.Application.ViewModels;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ConnectionContext _context = new();


        public async Task<ResponseModel<Consulta>> CriarConsulta(ConsultaViewModel consulta)
        {
            ResponseModel<Consulta> resposta = new();

            var novaConsulta = new Consulta(consulta.PacienteId, consulta.Medico_id, consulta.Descricao, consulta.Data_hora);
            
            try
            {
                await _context.Consulta.AddAsync(novaConsulta);
                await _context.SaveChangesAsync();

                resposta.Dados = novaConsulta;
                resposta.Mensagem = "Os dados foram salvos no sistema!";
                return resposta;

            }catch(Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public Task<ResponseModel<Consulta>> Editar()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<Consulta>>> ListarConsultas()
        {
            ResponseModel<List<Consulta>> resposta = new();

            try
            {
                var consultas = await _context.Consulta.ToListAsync();

                resposta.Dados = consultas;
                resposta.Mensagem = "Consultas listadas com sucesso!";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<object>>> ListarPorId(int id)
        {
            ResponseModel<List<object>> resposta = new();

            var hoje = DateTime.Today.ToUniversalTime();


            try
            {
                var consultas = await _context.Consulta.Where(c => c.paciente_id == id && c.data_hora >= hoje).ToListAsync();

                if (consultas == null || !consultas.Any())
                {
                    resposta.Mensagem = "Nenhuma consulta encontrada!";
                    resposta.Status = true;
                    return resposta;
                }

                var consultasComMedicos = new List<object>();

                foreach (var consulta in consultas)
                {
                    var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.id == consulta.medico_id);

                    consultasComMedicos.Add(new
                    {
                        id = consulta.id,
                        Medico = medico != null ? medico.nomecompleto : "Profissional não encontrado!",
                        Motivo = consulta.descricao,
                        Data = consulta.data_hora.ToString("dd/MM/yyyy  HH:mm")
                    });
                }

                resposta.Dados = consultasComMedicos;
                resposta.Mensagem = "Dados Coletados!";
                return resposta;
            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Consulta>>> ListarPorMedico(int medico)
        {
            ResponseModel<List<Consulta>> resposta = new();

            try
            {
                var response = await _context.Consulta.Where(c => c.medico_id == medico).ToListAsync();

                if(response == null)
                {
                    resposta.Mensagem = "Não há nenhuma consulta para este profissional!";
                    return resposta;
                }

                resposta.Dados = response;
                resposta.Mensagem = "Dados Coletados com sucesso!";
                return resposta;

            }catch(Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public Task<ResponseModel<Consulta>> Remover()
        {
            throw new NotImplementedException();
        }
    }
}
