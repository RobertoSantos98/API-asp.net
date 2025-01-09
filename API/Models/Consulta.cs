using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("consulta")]
    public class Consulta
    {
        public int id { get; private set; }
        public int paciente_id { get; private set; }
        public int medico_id { get; private set; }
        public string? descricao { get; private set; } = string.Empty;
        public DateTime data_hora { get; private set; }


        public Consulta(int pacienteId, int medicoId, string descricao, DateTime data)
        {
            this.paciente_id = pacienteId;
            this.medico_id = medicoId;
            this.descricao = descricao;
            this.data_hora = data;
        }

        public Consulta() { }

    }
}
