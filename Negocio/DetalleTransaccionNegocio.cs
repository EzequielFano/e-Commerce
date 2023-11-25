using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleTransaccionNegocio
    {
        public void generarDetallesTransaccion(Articulo articulo, int IdTransaccion)
        {
            //public float Precio { get; set; }
            //public int Cantidad { get; set; }
            //public Articulo Articulo { get; set; }
            //public int IdDetalleTransaccion { get; set; }

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedura("InsertarDetallesTransaccion");
                datos.setearParametro("@IdArticulo", articulo.IdArticulo);
                datos.setearParametro("@Cantidad", articulo.Cantidad);
                datos.setearParametro("@Precio", articulo.Precio * articulo.Cantidad);
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
