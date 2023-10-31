using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace ArticleManager_Web
{
    public partial class Carrito : System.Web.UI.Page
    {
        public static List<Articulo> articulosCarrito { get; set; }
        public int cantidad { get; set; }
        public bool borroCarrito { get; set; }
        public List<int> idArticulo { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            articulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
            cantidad = Session["cantidad"] != null ? (int)Session["cantidad"] : 0;
            if (!IsPostBack)
            {
                rpRepetidor.DataSource = articulosCarrito;
                rpRepetidor.DataBind();
            }

        }

        protected void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;

            foreach (Articulo aux in articulosCarrito)
            {
                if (aux.IdArticulo == int.Parse(valor))
                {
                    articulosCarrito.Remove(aux);
                    cantidad--;
                    Session["cantidad"] = cantidad;
                    Response.Redirect("Carrito.aspx");

                }

            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pago.aspx");
        }
    }
}