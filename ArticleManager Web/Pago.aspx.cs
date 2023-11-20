using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace ArticleManager_Web
{
    public partial class Pago : System.Web.UI.Page
    {
        public List<Articulo> articulosComprados { get; set; }
        public float PrecioTotal { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            PrecioTotal = 0;
            articulosComprados = (List<Articulo>)Session["ArticulosCarrito"];
            foreach(Articulo aux in articulosComprados)
            {
                PrecioTotal += (aux.Precio * aux.Cantidad);
            }
            dgvArticulosComprados.DataSource = articulosComprados;
            dgvArticulosComprados.DataBind();
            
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Envio.aspx");
        }
    }
}