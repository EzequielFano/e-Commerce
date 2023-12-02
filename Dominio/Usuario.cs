using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Direccion Direcciones { get; set; }

        public Usuario(string email,string nombre, string pass, bool admin)
        {
            Email=email;
            Password = pass;
            Nombre=nombre;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

        }

        public Usuario() { }
        
    }
}
