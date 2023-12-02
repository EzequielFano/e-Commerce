using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TransaccionNegocio
    {
        public int generarTransaccion(Usuario user, Direccion direccion, DateTime fecha, int tipoPago, float Importe)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                Transaccion transaccion = new Transaccion();
                datos.setearProcedura("IngresarTransaccion");
                datos.setearParametro("@idCliente", user.IdUsuario);
                datos.setearParametro("@FechaTransaccion", fecha);
                datos.setearParametro("@IdDomicilio", direccion.IdDireccion + 1);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@IdTipoPago", tipoPago);
                transaccion = ObtenerIdTransaccionCargada();
                datos.setearParametro("@NroEnvio", transaccion.IdTransaccion + 1);
                datos.setearParametro("Importe", Importe);
                datos.ejecutarAccion();
                transaccion = ObtenerIdTransaccionCargada();            
                return transaccion.IdTransaccion;

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }
        public Transaccion ObtenerIdTransaccionCargada()
        {
            AccesoDatos datos = new AccesoDatos();
            Transaccion aux = new Transaccion();

            try
            {

                datos.setearConsulta("SELECT IDENT_CURRENT('TRANSACCIONES') AS IdTransaccion");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.IdTransaccion = Convert.ToInt32(datos.Lector["IdTransaccion"]);

                }

                return aux;
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Transaccion> traerListado()
        {
            List<Transaccion> transaccions = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {

                datos.setearConsulta("Select * FROM TRANSACCIONES");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Transaccion transaccion = new Transaccion();
                    transaccion.IdTransaccion = datos.Lector.GetInt32(0);
                    transaccion.User = new Usuario();
                    transaccion.User.IdUsuario = datos.Lector.GetInt32(1);
                    transaccion.FechaTransaccion = datos.Lector.GetDateTime(2);
                    transaccion.Direccion = new Direccion();
                    transaccion.Direccion.IdDireccion = datos.Lector.GetInt32(3);
                    transaccion.Estado = (EstadoEnvio)datos.Lector.GetInt32(4);
                    transaccion.TipoPago = (TipoPago)datos.Lector.GetInt32(5);
                    transaccion.NroSeguimiento = datos.Lector.GetInt32(6);
                    transaccion.Importe = (int)datos.Lector.GetSqlMoney(7);
                    transaccions.Add(transaccion);
                }

                return transaccions;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public int cantidadTransacciones()
        {
            AccesoDatos datos = new AccesoDatos();
            SqlParameter outputParameter = new SqlParameter("@CantidadTransacciones", System.Data.SqlDbType.Int);
            outputParameter.Direction = System.Data.ParameterDirection.Output;
         

            try
            {
                int cantidad = 0;
                datos.setearProcedura("TraerCantidadTransacciones");
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
