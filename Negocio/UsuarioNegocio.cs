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
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUsuario"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Cliente;

                    return true;
                }
                return false;


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<Usuario> listarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select * FROM Usuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = datos.Lector.GetInt32(0);
                    usuario.Nombre = datos.Lector["Nombre"].ToString();
                    usuario.Apellido = datos.Lector["Apellido"].ToString();
                    usuario.Email = datos.Lector["Email"].ToString();
                    usuario.Password = datos.Lector["Pass"].ToString();
                    usuario.TipoUsuario = (TipoUsuario)datos.Lector.GetInt32(5);
                    usuario.Status = (bool)datos.Lector["Status"];
                    usuarios.Add(usuario);
                }

                return usuarios;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
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
                    user.Password = datos.Lector["Pass"].ToString();
                    user.TipoUsuario = (TipoUsuario)datos.Lector["TipoUsuario"];
                    user.Status = (bool)datos.Lector["Status"];
                }

                return user;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
        public void UpdateStatusUsuario(bool status, int id)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedura("UpdateStatusUsuario");
                datos.setearParametro("@IdUsuario", id);
                datos.setearParametro("@NuevoStatus", status);
                datos.ejecutarLectura();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool EditarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Usuario user = new Usuario();
            try
            {
                datos.setearConsulta("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Pass = @Pass, TipoUsuario = @TipoUsuario WHERE IdUsuario = @IdUsuario");
                datos.setearParametro("@IdUsuario", usuario.IdUsuario);
                datos.setearParametro("@Nombre", usuario.Nombre);
                datos.setearParametro("@Apellido", usuario.Apellido);
                datos.setearParametro("@Email", usuario.Email);
                datos.setearParametro("@Pass", usuario.Password);
                if(usuario.TipoUsuario == TipoUsuario.Cliente)
                {
                datos.setearParametro("@TipoUsuario", "1");
                }
                else
                {
                datos.setearParametro("@TipoUsuario", "2");
                }
                datos.setearParametro("Status", usuario.Status);
                datos.ejecutarAccion();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
