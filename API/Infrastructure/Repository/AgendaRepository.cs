using API.Application.ViewModels;
using API.Domain.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repository
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly ConnectionContext _context = new();

        public async Task<ResponseModel<List<AgendaDTO>>> ListarAgenda()
        {
            ResponseModel<List<AgendaDTO>> resposta = new();

            try
            {
                var hoje = DateOnly.FromDateTime(DateTime.Today);

                var response = await _context.Agenda.Where(a => a.data >= hoje).ToListAsync();

                if (response == null)
                {
                    resposta.Mensagem = "Nenhum dado foi encontrado no Sistema!";
                    return resposta;
                }

                var listagemFinal = new List<AgendaDTO>();

                foreach (var agenda in response)
                {
                    var idConsulta = await _context.Consulta.FirstOrDefaultAsync(a => a.id == agenda.consulta_id);

                    if(idConsulta == null)
                    {
                        listagemFinal.Add(new AgendaDTO
                        {
                            id = agenda.id,
                            data = agenda.data.ToString("dd/MM/yyyy"),
                            hora = agenda.horario.ToString("HH:mm"),
                            disponivel = true,
                            medico = "Disponível"
                        }); ;
                    }
                    else
                    {
                        var medico = await _context.Medicos.FirstOrDefaultAsync(m => m.id == idConsulta.medico_id);

                        if(medico != null)
                        {
                            listagemFinal.Add(new AgendaDTO
                            {
                                id = agenda.id,
                                data = agenda.data.ToString("dd/MM/yyyy"),
                                hora = agenda.horario.ToString("HH:mm"),
                                disponivel = false,
                                medico = medico.nomecompleto
                            });
                        }
                    }
                }

                var listaOrdenada = listagemFinal.OrderBy(item => item.id).ToList();

                resposta.Dados = listaOrdenada;
                resposta.Mensagem = "Todos os dados foram recuperados!";
                return resposta;

            }catch(Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<Agenda>>> ListarAgendaPorDia(DateOnly data)
        {
            ResponseModel<List<Agenda>> resposta = new();

            try
            {
                var response = await _context.Agenda.Where(a => a.data == data).ToListAsync();

                if (response == null)
                {
                    resposta.Mensagem = "Não foi encontrado nenhum dado no sistema!";
                    return resposta;
                }

                resposta.Dados = response;
                resposta.Mensagem = "Todos os dados foram coletados!";
                return resposta;

            }
            catch(Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<Agenda>> MarcarConsulta(AgendaViewModel agenda)
        {
            ResponseModel<Agenda> resposta = new();
      

            try
            {
                var response = await _context.Agenda.FirstOrDefaultAsync(c => c.data == agenda.data && c.horario == agenda.hora);
                
                if(response == null){
                    resposta.Mensagem = "Não foi encontrado a hora em questão!";
                    return resposta;
                }

                response.AtualizarConsulta(agenda.consulta_id);

                _context.Agenda.Update(response);
                await _context.SaveChangesAsync();

                resposta.Dados = response;
                resposta.Mensagem = "Consulta agendada!";
                return resposta;
               

            }
            catch (Exception e)
            {
                resposta.Mensagem = e.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //public async Task<ResponseModel<List<object>>> ListarTodaAgenda()
        //{
        //    ResponseModel<List<object>> resposta = new();

        //    try
        //    {
        //        var hoje = DateOnly.FromDateTime(DateTime.Today);

        //        var response = await _context.Agenda.Where(a => a.data >= hoje).ToListAsync();

        //        var ListagemFinal = new List<object>();

        //        if(response == null)
        //        {
        //            resposta.Mensagem = "Nenhum dado encontrado!";
        //            resposta.Status = false;
        //            return resposta;
        //        }

        //        foreach(var consulta in response)
        //        {
        //            var verificarConsulta = await _context.Consulta.Where(c => c.id == consulta.id).ToListAsync();

        //            if(verificarConsulta != null)
        //            {

        //            }


        //        }



        //        return ListagemFinal;


        //    }
        //    catch(Exception e)
        //    {
        //        resposta.Mensagem = e.Message;
        //        resposta.Status = false;
        //        return resposta;
        //    }
        //}

    }
}
