using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DireccionNegocio
    {

        public void generarDireccion(Direccion direccion, int IdTransaccion, int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedura("InsertarDireccion");
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.setearParametro("@IdPais", 1);
                datos.setearParametro("@IdProvincia", direccion.Provincia.IdProvincia);
                datos.setearParametro("@IdCiudad", direccion.Ciudad.IdCiudad);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Piso", direccion.Piso);
                datos.setearParametro("@Departamento", direccion.Departamento);
                datos.setearParametro("@IdUsuario", IdUsuario);
                datos.setearParametro("Status", false);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void generarDireccionDeUsuario(Direccion direccion, int IdTransaccion, int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearProcedura("InsertarDireccionDeUsuario");
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.setearParametro("@IdPais", 1);
                datos.setearParametro("@IdProvincia", direccion.Provincia.IdProvincia);
                datos.setearParametro("@IdCiudad", direccion.Ciudad.IdCiudad);
                datos.setearParametro("@Calle", direccion.Calle);
                datos.setearParametro("@Numero", direccion.Numero);
                datos.setearParametro("@Piso", direccion.Piso);
                datos.setearParametro("@Departamento", direccion.Departamento);
                datos.setearParametro("@IdUsuario", IdUsuario);
                datos.setearParametro("Status", false);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public Direccion DireccionSegunIdTransaccion(int IdTransaccion)
        {
            Direccion direccion = new Direccion();
            AccesoDatos datos = new AccesoDatos();
            CiudadNegocio ciudadNegocio = new CiudadNegocio();
            ProvinciaNegocio negocioProvincia = new ProvinciaNegocio();
            try
            {
                datos.setearProcedura("ObtenerDireccionPorTransaccion");
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    direccion.IdDireccion = datos.Lector.GetInt32(0);
                    if (direccion.Pais == null)
                    {
                        direccion.Pais = new Pais();
                    }
                    direccion.Pais.IdPais = datos.Lector.GetInt32(2);
                    direccion.Pais.Nombre = "Argentina";
                    if (direccion.Provincia == null)
                    {
                        direccion.Provincia = new Provincia();
                    }
                    direccion.Provincia.IdProvincia = datos.Lector.GetInt32(3);
                    direccion.Provincia.Nombre = negocioProvincia.listarProvinciaXId(direccion.Provincia.IdProvincia);
                    if (direccion.Ciudad == null)
                    {
                        direccion.Ciudad = new Ciudad();
                    }
                    direccion.Ciudad.IdCiudad = datos.Lector.GetInt32(4);
                    direccion.Ciudad.Nombre = ciudadNegocio.listarCiudadXId(direccion.Ciudad.IdCiudad);
                    direccion.Calle = datos.Lector["Calle"].ToString();
                    direccion.Numero = datos.Lector.GetInt32(6);
                    direccion.Piso = datos.Lector.GetInt32(7);
                    direccion.Departamento = datos.Lector["Departamento"].ToString();
                }
                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Direccion obtenerDireccionesPorUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Direccion direccion = new Direccion();
            CiudadNegocio ciudadNegocio = new CiudadNegocio();
            ProvinciaNegocio negocioProvincia = new ProvinciaNegocio();
            try
            {
                datos.setearProcedura("ObtenerDireccionesPorUsuario");
                datos.setearParametro("IdUsuario", IdUsuario);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                   
                    direccion.IdDireccion = datos.Lector.GetInt32(0);
                    if (direccion.Pais == null)
                    {
                        direccion.Pais = new Pais();
                    }
                    direccion.Pais.IdPais = datos.Lector.GetInt32(2);
                    direccion.Pais.Nombre = "Argentina";
                    if (direccion.Provincia == null)
                    {
                        direccion.Provincia = new Provincia();
                    }
                    direccion.Provincia.IdProvincia = datos.Lector.GetInt32(3);
                    direccion.Provincia.Nombre = negocioProvincia.listarProvinciaXId(direccion.Provincia.IdProvincia);
                    if (direccion.Ciudad == null)
                    {
                        direccion.Ciudad = new Ciudad();
                    }
                    direccion.Ciudad.IdCiudad = datos.Lector.GetInt32(4);
                    direccion.Ciudad.Nombre = ciudadNegocio.listarCiudadXId(direccion.Ciudad.IdCiudad);
                    direccion.Calle = datos.Lector["Calle"].ToString();
                    direccion.Numero = datos.Lector.GetInt32(6);
                    direccion.Piso = datos.Lector.GetInt32(7);
                    direccion.Departamento = datos.Lector["Departamento"].ToString();
                    direccion.Status = (bool)datos.Lector["Status"];
                   
                }

                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
        public Direccion obtenerDireccionDelUsuario(int IdUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            Direccion direccion = new Direccion();
            CiudadNegocio ciudadNegocio = new CiudadNegocio();
            ProvinciaNegocio negocioProvincia = new ProvinciaNegocio();
            try
            {
                datos.setearProcedura("ObtenerDireccionDelUsuario");
                datos.setearParametro("IdUsuario", IdUsuario);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {

                    direccion.IdDireccion = datos.Lector.GetInt32(0);
                    if (direccion.Pais == null)
                    {
                        direccion.Pais = new Pais();
                    }
                    direccion.Pais.IdPais = datos.Lector.GetInt32(2);
                    direccion.Pais.Nombre = "Argentina";
                    if (direccion.Provincia == null)
                    {
                        direccion.Provincia = new Provincia();
                    }
                    direccion.Provincia.IdProvincia = datos.Lector.GetInt32(3);
                    direccion.Provincia.Nombre = negocioProvincia.listarProvinciaXId(direccion.Provincia.IdProvincia);
                    if (direccion.Ciudad == null)
                    {
                        direccion.Ciudad = new Ciudad();
                    }
                    direccion.Ciudad.IdCiudad = datos.Lector.GetInt32(4);
                    direccion.Ciudad.Nombre = ciudadNegocio.listarCiudadXId(direccion.Ciudad.IdCiudad);
                    direccion.Calle = datos.Lector["Calle"].ToString();
                    direccion.Numero = datos.Lector.GetInt32(6);
                    direccion.Piso = datos.Lector.GetInt32(7);
                    direccion.Departamento = datos.Lector["Departamento"].ToString();
                    direccion.Status = (bool)datos.Lector["Status"];

                }

                return direccion;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void UpdateStatusDireccion(bool status, int id)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedura("UpdateStatusDireccion");
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

        public void UpdateStatusDireccionDelUsuario(bool status, int id)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedura("UpdateStatusDireccionDelUsuario");
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



        public int cantidadDirecciones()
        {
            AccesoDatos datos = new AccesoDatos();
            SqlParameter outputParameter = new SqlParameter("@CantidadDirecciones", System.Data.SqlDbType.Int);
            outputParameter.Direction = System.Data.ParameterDirection.Output;


            try
            {
                int cantidad = 0;
                datos.setearProcedura("TraerCantidadDirecciones");
                datos.ejecutarLectura();

                cantidad = Convert.ToInt32(outputParameter.Value);
                return cantidad + 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
