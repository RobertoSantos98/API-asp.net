using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("medicos")]
    public class Medico
    {
        [Key]
        public int id { get; private set; }
        public string nomecompleto { get; private set; }
        public string especializacao { get; private set; }

        public Medico(string nomecompleto, string especializacao)
        {
            this.nomecompleto = nomecompleto;
            this.especializacao = especializacao;

        }
    }
}
