using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int IdArticulo{ get; set; }
        public string CodigoArticulo { get; set; }  
        public string NombreArticulo { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Imagen URLImagen { get; set; }
        public float Precio { get; set; }
    }
}
