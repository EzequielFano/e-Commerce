using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetalleTransaccionNegocio
    {
        public void generarDetallesTransaccion(Articulo articulo, int IdTransaccion)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedura("InsertarDetallesTransaccion");
                datos.setearParametro("@IdArticulo", articulo.IdArticulo);
                datos.setearParametro("@Cantidad", articulo.Cantidad);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public List<DetalleTransaccion> getDetalleTransaccionListXId(int IdTransaccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<DetalleTransaccion> DetallesTransaccion = new List<DetalleTransaccion>();

                datos.setearProcedura("ListarDetallesPorTransaccion");
                datos.setearParametro("@IdTransaccion", IdTransaccion);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    DetalleTransaccion aux = new DetalleTransaccion();
                    if (aux.Articulo == null)
                    {
                        aux.Articulo = new Articulo();
                    }
                    aux.Articulo.IdArticulo = datos.Lector.GetInt32(1);
                    aux.Cantidad = datos.Lector.GetInt32(2);
                    aux.Precio = (int)datos.Lector.GetSqlMoney(3);
                    aux.IdTransaccion = IdTransaccion;
                    DetallesTransaccion.Add(aux);
                }
                return DetallesTransaccion;
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }

        }
    }
}
