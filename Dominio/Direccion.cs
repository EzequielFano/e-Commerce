using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direccion
    {
        public int IdTransaccion { get; set; }
        public Pais Pais { get; set; }
        public Provincia Provincia { get; set; }
        public Ciudad Ciudad { get; set; }
       
        public string Calle { get; set; }
        public int Piso { get; set; }
        public string Departamento { get; set; }

    }
}
