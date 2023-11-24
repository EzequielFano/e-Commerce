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
        public List<Articulo> ArticulosComprados { get; set; }
        public float PrecioTotal { get; set; }
        public Usuario Usuario { get; set; }
        public Direccion Direccion { get; set; }
        public List<DetalleTransaccion> Detalles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario = (Usuario)Session["usuario"];

            if (!IsPostBack)
            {
                PrecioTotal = 0;
                ArticulosComprados = (List<Articulo>)Session["ArticulosCarrito"];
                foreach (Articulo articulo in ArticulosComprados)
                {
                    PrecioTotal += (articulo.Precio * articulo.Cantidad);
                }
                dgvArticulosComprados.DataSource = ArticulosComprados;
                dgvArticulosComprados.DataBind();
            }

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Envio.aspx");
        }
    }
}