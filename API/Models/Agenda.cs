using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("agenda")]
    public class Agenda
    {
        public int id { get; private set; }
        public DateOnly data {  get; private set; }
        public TimeOnly horario { get; private set; }
        public bool disponivel { get; set; }
        public int? consulta_id { get; set; }

        public Agenda() { }

        public void AtualizarConsulta(int novoId)
        {
            consulta_id = novoId;
            disponivel = false;
        }
    }
}
