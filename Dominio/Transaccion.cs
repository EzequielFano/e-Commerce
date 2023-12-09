﻿using System;
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
    public enum EstadoEnvio
    {
        INICIADO = 1,
        ENVIADO = 2,
        RETIRO_EN_LOCAL = 3,
        RECIBIDO = 4
    }
    public class Transaccion
    {
        public int IdTransaccion { get; set; }
        public Usuario User { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public Direccion Direccion { get; set; }
        public float Importe { get; set; }
        public int NroSeguimiento { get; set; }
        public EstadoEnvio Estado { get; set; }
        public TipoPago TipoPago { get; set; }
    }
}
