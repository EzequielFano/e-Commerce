using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Microsoft.Win32;
using static System.Net.Mime.MediaTypeNames;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> TraerListadoSP()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            int auximg = 0;

            try
            {
                datos.setearProcedura("storedListar");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    aux.Precio = (int)datos.Lector.GetSqlMoney(8);
                    aux.URLImagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.URLImagen.URL = (string)datos.Lector["ImagenUrl"];
                        if (aux.URLImagen.URL == " ")
                        {
                            aux.URLImagen.URL = "https://redthread.uoregon.edu/files/original/affd16fd5264cab9197da4cd1a996f820e601ee4.png";
                        }
                        auximg++;
                    }
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    articulos.Add(aux);

                }
                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> TraerListadoCompletoSP()
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            int auximg = 0;

            try
            {
                datos.setearProcedura("storedListarTodos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    aux.Precio = (int)datos.Lector.GetSqlMoney(8);
                    aux.URLImagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.URLImagen.URL = (string)datos.Lector["ImagenUrl"];
                        if (aux.URLImagen.URL == " ")
                        {
                            aux.URLImagen.URL = "https://redthread.uoregon.edu/files/original/affd16fd5264cab9197da4cd1a996f820e601ee4.png";
                        }
                        auximg++;
                    }
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.Status = (bool)datos.Lector["Status"];
                    articulos.Add(aux);

                }
                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public List<Articulo> TraerListadoCompletoxId(int id)
        {
            List<Articulo> articulos = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            int auximg = 0;

            try
            {
                datos.setearProcedura("storedListarPorIdArticulo");
                datos.setearParametro("IdArticulo", id);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    if (datos.Lector["Categoria"] is DBNull)
                    {
                        aux.Categoria = null;
                    }
                    else
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    aux.Precio = (int)datos.Lector.GetSqlMoney(8);
                    aux.URLImagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.URLImagen.URL = (string)datos.Lector["ImagenUrl"];
                        if (aux.URLImagen.URL == " ")
                        {
                            aux.URLImagen.URL = "https://redthread.uoregon.edu/files/original/affd16fd5264cab9197da4cd1a996f820e601ee4.png";
                        }
                        auximg++;
                    }
                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    articulos.Add(aux);

                }
                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                Imagen imag = new Imagen();

                datos.setearProcedura("agregarArticulo");
                datos.setearParametro("@Codigo", articulo.CodigoArticulo);
                datos.setearParametro("@Nombre", articulo.NombreArticulo);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("Cantidad", articulo.Cantidad);
                datos.ejecutarAccion();
                imag = imagenNegocio.ObtenerIDarticuloCargado();
                datos.setearConsulta("INSERT INTO IMAGENES (IdArticulo,ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setearParametro("@IdArticulo", imag.IdImagen);
                datos.setearParametro("@ImagenUrl", articulo.URLImagen.URL);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public void modificarArticulo(Articulo articulo, string URLNueva)
        {
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("UPDATE ARTICULOS SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio , Cantidad = @Cantidad WHERE Id = @IdArticulo");
                datos.setearParametro("IdArticulo", articulo.IdArticulo);
                datos.setearParametro("@Codigo", articulo.CodigoArticulo);
                datos.setearParametro("@Nombre", articulo.NombreArticulo);
                datos.setearParametro("@Descripcion", articulo.Descripcion);
                datos.setearParametro("@IdMarca", articulo.Marca.Id);
                datos.setearParametro("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametro("@Precio", articulo.Precio);
                datos.setearParametro("@Cantidad", articulo.Cantidad);
                datos.ejecutarAccion();

                datos.setearConsulta("UPDATE IMAGENES SET ImagenUrl = @ImagenUrlNueva WHERE ImagenUrl = @ImagenUrl;");
                datos.setearParametro("@ImagenUrl", articulo.URLImagen.URL);
                datos.setearParametro("@ImagenUrlNueva", URLNueva);
               
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }


        public List<Imagen> verImagenesArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Imagen> listImg = new List<Imagen>();
            Articulo aux = new Articulo();
            int auximg = 0;


            datos.setearProcedura("ObtenerImagenesxId");
            datos.setearParametro("IdArticulo", id);
            datos.ejecutarLectura();
            int auxId = 1;
            while (datos.Lector.Read())
            {
                aux.URLImagen = new Imagen();

                if (!(datos.Lector["ImagenUrl"] is DBNull))
                {
                    aux.URLImagen.URL = (string)datos.Lector["ImagenUrl"];
                    aux.URLImagen.IdImagen = auxId;

                    if (aux.URLImagen.URL == " ")
                    {
                        aux.URLImagen.URL = "https://redthread.uoregon.edu/files/original/affd16fd5264cab9197da4cd1a996f820e601ee4.png";
                    }
                    auximg++;
                }
                auxId++;
                listImg.Add(aux.URLImagen);
            }
            return listImg;
        }
        public List<Articulo> verDetallesArticulo(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo aux = new Articulo();
            List<Articulo> articulos = new List<Articulo>();

            datos.setearProcedura("ObtenerArticuloPorId");
            datos.setearParametro("IdArticulo", Id);
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                aux.IdArticulo = Id;
                aux.CodigoArticulo = (string)datos.Lector["CodigoArticulo"];
                aux.NombreArticulo = (string)datos.Lector["NombreArticulo"];
                aux.Descripcion = (string)datos.Lector["DescripcionArticulo"];
                aux.Marca = new Marca();
                if (datos.Lector["Marca"] is DBNull)
                {
                    aux.Marca = null;
                }
                else
                {
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                }

                aux.Categoria = new Categoria();
                if (datos.Lector["Categoria"] is DBNull)
                {
                    aux.Categoria = null;
                }
                else
                {
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                }


                aux.Precio = (int)datos.Lector.GetSqlMoney(5);
                aux.Cantidad = (int)datos.Lector["Cantidad"];

                articulos.Add(aux);
            }
            return articulos;
        }

        public void eliminarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM ARTICULOS where id = @IdArticulo");
                datos.setearParametro("@IdArticulo", id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion AS Marca, A.IdCategoria, A.IdMarca, C.Descripcion AS Categoria, A.Precio, IM.ImagenUrl\r\nFROM ARTICULOS A\r\nINNER JOIN IMAGENES IM ON A.Id = IM.IdArticulo\r\nINNER JOIN MARCAS M ON A.IdMarca = M.Id\r\nLEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id\r\nWHERE ";
                if (campo == "Categoria")
                {
                    consulta += "C.Descripcion = '" + criterio + "'";
                }
                else if (campo == "Marca")
                {
                    consulta += "M.Descripcion = '" + criterio + "'";
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A.Nombre like '" + filtro + "%'";
                            break;
                        case "Termina con":
                            consulta += "A.Nombre like '%" + filtro + "'";
                            break;
                        case "Contiene":
                            consulta += "A.Nombre like '%" + filtro + "%'";
                            break;
                    }
                }




                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.IdArticulo = datos.Lector.GetInt32(0);
                    aux.CodigoArticulo = (string)datos.Lector["Codigo"];
                    aux.NombreArticulo = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.Precio = (int)datos.Lector.GetSqlMoney(8);
                    aux.URLImagen = new Imagen();
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.URLImagen.URL = (string)datos.Lector["ImagenUrl"];
                    }
                    lista.Add(aux);

                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool revisarRepetidos(List<Articulo> articulos, int Id)
        {
            bool esRepetido = false;
            int cantidad = articulos.Count();
            for (int i = 0; i < cantidad; i++)
            {
                if (articulos[i].IdArticulo == Id)
                {
                    esRepetido = true;
                }
            }

            return esRepetido;
        }

        public void restarStock(int cantidad, int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = new Articulo();

            try
            {
                datos.setearProcedura("RestarCantidadArticulo");
                datos.setearParametro("@IdArticulo", Id);
                datos.setearParametro("@CantidadARestar", cantidad);
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
        public void sumarStock(int cantidad, int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Articulo articulo = new Articulo();

            try
            {
                datos.setearProcedura("SumarCantidadArticulo");
                datos.setearParametro("@IdArticulo", Id);
                datos.setearParametro("@CantidadARestar", cantidad);
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
        public void UpdateStatus(bool status, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            

            try
            {
                datos.setearProcedura("UpdateStatus");
                datos.setearParametro("@ArticuloId", id);
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

  
    }

}
