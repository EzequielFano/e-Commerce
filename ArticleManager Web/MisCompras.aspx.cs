﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class MisCompras : System.Web.UI.Page
    {
        public List<Transaccion> TransaccionesMiCompra { get; set; }
        public List<Detalles> DetallesTransaccionesMisCompras { get; set; }
        public Direccion DireccionMisCompras { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
               
                if (!IsPostBack)
                {
                    BindComprasData();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void BindComprasData()
        {
            TransaccionNegocio negocio = new TransaccionNegocio();
            List<Transaccion> Transacciones = new List<Transaccion>();
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["usuario"];
            TransaccionesMiCompra = negocio.traerListado();
            foreach (Transaccion aux in TransaccionesMiCompra)
            {
                if (aux.User.IdUsuario == usuario.IdUsuario)
                {
                    Transacciones.Add(aux);
                    //aux.Direccion = negocioDireccion.DireccionSegunIdTransaccion(aux.IdTransaccion);
                }
            }

            rptMisCompras.DataSource = Transacciones;
            rptMisCompras.DataBind();
        }
        protected void rptMisCompras_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
        }

    }
}