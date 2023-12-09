using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listarProvincias()
        {
            List<Provincia> provincias = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearProcedura("StoredListarProvincias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Provincia provincia = new Provincia();
                    provincia.IdProvincia = datos.Lector.GetInt32(0);
                    provincia.Nombre = (string)datos.Lector["Nombre"];
                    provincias.Add(provincia);  
                }
            return provincias;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }

        }


        public string listarProvinciaXId(int Id)
        {
            string provinciaNombre = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedura("ObtenerNombreProvincia");
                datos.setearParametro("IdProvincia", Id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Provincia provincia = new Provincia();
                    
                    provincia.Nombre = (string)datos.Lector["Nombre"];
                    provinciaNombre = provincia.Nombre;
                }
                return provinciaNombre ;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
