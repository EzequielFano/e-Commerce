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
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
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
