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
        public void generarTransaccion(Usuario user, Direccion direccion, DateTime fecha, int tipoPago)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearProcedura("IngresarTransaccion");
                datos.setearParametro("@idCliente", user.IdUsuario);
                datos.setearParametro("@FechaTransaccion", fecha);
                datos.setearParametro("@IdDomicilio", direccion.IdDireccion + 1);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@IdTipoPago", tipoPago);
                datos.setearParametro("@NroEnvio", cantidadTransacciones() + 1);
                datos.ejecutarAccion();
                //public int IdTransaccion { get; set; }
                //public Usuario User { get; set; }
                //public List<DetalleTransaccion> DetalleTransacciones { get; set; }
                //public DateTime FechaTransaccion { get; set; }
                //public Direccion Direccion { get; set; }
                //public float Importe { get; set; }
                //public int NroSeguimiento { get; set; }
                //public EstadoEnvio Estado { get; set; }
                //public TipoPago TipoPago { get; set; }


            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }


        public List<Transaccion> traerListado()
        {
            List<Transaccion> transaccions = new List<Transaccion>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {

                datos.setearConsulta("Select * FROM TRANSACCION");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Transaccion transaccion = new Transaccion();

                    transaccion.User.IdUsuario = datos.Lector.GetInt32(0);
                    DateTime time = DateTime.Parse(datos.Lector.ToString());
                    transaccion.Direccion.IdDireccion = datos.Lector.GetInt32(2);
                    transaccion.Estado = (EstadoEnvio)datos.Lector.GetInt32(3);
                    transaccion.TipoPago = (TipoPago)datos.Lector.GetInt32(4);
                    transaccion.NroSeguimiento = datos.Lector.GetInt32(5);
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
