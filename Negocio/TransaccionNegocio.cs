using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TransaccionNegocio
    {
        public void generarTransaccion(Usuario user, Direccion direccion, DateTime fecha, TipoPago tipoPago)
        {
            AccesoDatos datos = new AccesoDatos();
           
            try
            {
                datos.setearProcedura("IngresarTransaccion");
                datos.setearParametro("@idCliente", user.IdUsuario) ;
                datos.setearParametro("@FechaTransaccion", fecha);
                datos.setearParametro("@IdDomicilio", direccion.IdDireccion);
                datos.setearParametro("@Estado", 1);
                datos.setearParametro("@IdTipoPago", tipoPago);
                datos.setearParametro("@NroEnvio", cantidadTransacciones()+1);
          
              
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
        public int cantidadTransacciones()
        {
            int cantidad = 0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedura("TraerCantidadTransacciones");
                datos.ejecutarLectura();
                cantidad = datos.Lector.GetInt32(0);
                return cantidad + 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
