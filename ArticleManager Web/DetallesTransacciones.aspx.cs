using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace ArticleManager_Web
{
    public partial class DetallesTransacciones : System.Web.UI.Page
    {
        public List<DetalleTransaccion> listaDetalles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["idTransaccion"].ToString());
            DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
            listaDetalles = negocioDetalles.getDetalleTransaccionListXId(id);

        }
    }
}