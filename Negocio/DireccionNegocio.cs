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
