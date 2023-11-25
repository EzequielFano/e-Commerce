using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleTransaccion
    { 
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public List <Articulo> ArticulosComprados { get; set; }
        public int IdDetalleTransaccion { get; set; }

    }
}
