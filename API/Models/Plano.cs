
namespace API.Models
{
    public class Plano
    {
        public int id { get; private set; }
        public string plano { get; private set; }
        public bool status { get; private set; }
        public Usuario usuario { get; private set; }

        public Plano(string plano, bool status, Usuario usuario)
        {
            this.plano = plano;
            this.status = status;
            this.usuario = usuario;
        }
    }
}
