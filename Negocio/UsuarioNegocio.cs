using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool Loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedura("loguearUsuario");
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Pass", usuario.Password);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["IdUsuario"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;

                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public bool crearUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedura("CrearUsuario");
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Password);
                datos.setearParametro("@TipoUsuario", '1');
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public Usuario traerUsuarioXId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario user = new Usuario();
            try
            {
                datos.setearProcedura("ObtenerDatosUsuario");
                datos.setearParametro("IdUsuario", Id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    user.IdUsuario = Id;
                    user.Nombre = datos.Lector["Nombre"].ToString();
                    user.Apellido = datos.Lector["Apellido"].ToString();
                    user.Email = datos.Lector["Email"].ToString();
                }

                return user;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
