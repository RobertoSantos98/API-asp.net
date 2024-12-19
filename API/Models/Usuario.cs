using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        public int id { get; private set; }
        public string nomecompleto { get; private set; }
        public string cpf { get; private set; }
        public DateOnly datanascimento { get; private set; }

        public Usuario(string nomecompleto, string cpf, DateOnly datanascimento)
        {
            this.nomecompleto = nomecompleto;
            this.cpf = cpf;
            this.datanascimento = datanascimento;
        }

        public Usuario(int id, string nomecompleto, string cpf, DateOnly datanascimento)
        {
            this.id = id;
            this.nomecompleto = nomecompleto;
            this.cpf = cpf;
            this.datanascimento = datanascimento;
        }
    }
}
