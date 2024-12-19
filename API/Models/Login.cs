using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("login")]
    public class Login
    {
        public int id { get; private set; }
        public string login { get; private set; }
        public string password { get; private set; }

        public int idusuario { get; private set; }
        //public Usuario idusuario { get; private set; }

        public Login(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public Login(string login, string password, int idusuario)
        {
            this.login = login;
            this.password = password;
            this.idusuario = idusuario;
        }

        public Login()
        {
        }
    }
}
