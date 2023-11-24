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
        public static List<Articulo> ArticulosCarrito { get; set; }
        public int CantidadEnCarrito { get; set; }
        public bool borroCarrito { get; set; }
        public List<int> idArticulo { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
            CantidadEnCarrito = Session["CantidadEnCarrito"] != null ? (int)Session["CantidadEnCarrito"] : 0;

            if (!IsPostBack)
            {
                rpRepetidor.DataSource = ArticulosCarrito;
                rpRepetidor.DataBind();
            }
           
        }

        protected void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            ArticulosNegocio negocio = new ArticulosNegocio();

            foreach (Articulo aux in ArticulosCarrito)
            {
                if (aux.IdArticulo == int.Parse(valor))
                {
                    ArticulosCarrito.Remove(aux);
                    negocio.sumarStock(aux.Cantidad, aux.IdArticulo);
                    CantidadEnCarrito--;
                    Session["CantidadEnCarrito"] = CantidadEnCarrito;
                    Response.Redirect("Carrito.aspx");

                }

            }

        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Session.Add("articulosCarrito", ArticulosCarrito);
            Response.Redirect("Pago.aspx");
        }
    }
}