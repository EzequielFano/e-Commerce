using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoPago
    {
        EFECTIVO = 1,
        TRANSFERENCIA = 2,
        MERCADOPAGO =3
    }
    public class Transaccion
    {
        public int IdTransaccion { get; set; }
        public Usuario User { get; set; }
        public List<DetalleTransaccion> DetalleTransaccions { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public Direccion Direccion { get; set; }
        public float Importe { get; set; }
        public string NroSeguimiento { get; set; }
        public int MyProperty { get; set; }
        public int Estado { get; set; }
        public TipoPago TipoPago { get; set; }
       

    }
}
