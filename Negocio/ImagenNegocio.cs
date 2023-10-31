using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{

    public class ImagenNegocio
    {
        public List<Imagen> ListarImagenes()
        {
            List<Imagen> Lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearProcedura("storedListarImagenes");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Imagen aux = new Imagen();

                    aux.IdImagen = (int)datos.Lector["IdArticulo"];

                    aux.URL = (string)datos.Lector["ImagenUrl"];
                   
                    Lista.Add(aux);
                }
                return Lista;
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
        public void AgregarImgen(Imagen imagen)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into IMAGENES (IdArticulo,ImagenUrl) values (@IdArticulo,@ImagenUrl)");
                datos.setearParametro("@IdArticulo", imagen.IdImagen);
                datos.setearParametro("@ImagenUrl", imagen.URL);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
        public Imagen ObtenerIDarticuloCargado()
        {
            AccesoDatos datos = new AccesoDatos();
            Imagen aux = new Imagen();

            try
            {
                
                datos.setearConsulta("SELECT IDENT_CURRENT('ARTICULOS') AS IdArticulo");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux.IdImagen = Convert.ToInt32(datos.Lector["IdArticulo"]);

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
    }
}

