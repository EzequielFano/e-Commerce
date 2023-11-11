using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using System.Collections;


namespace ArticleManager_Web
{
    public partial class Articulos1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        static public List<Articulo> ArticulosCarrito { get; set; }
        static public int cantidad { get; set; }
        public int cantidadAComprar { get; set; }
        public List<Imagen> ListaImagenes { get; set; }

        public List<int> idArticulo { get; set; }
        public bool filtrado { get; set; }
        public bool session { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                filtrado = Session["Filtrado"] != null ? true : false;
                ListaArticulos = (List<Articulo>)Session["ListaArticulos"];
                session = Session["session"] != null ? (bool)Session["session"] : false;
                cantidad = Session["cantidad"] != null ? (int)Session["cantidad"] : 0;
                if (!filtrado)
                {
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    ListaArticulos = negocio.TraerListadoSP();
                    if (!IsPostBack)
                    {
                        rpRepetidor.DataSource = ListaArticulos;
                        rpRepetidor.DataBind();
                    }
                }
                else
                {
                    rpRepetidor.DataSource = ListaArticulos;
                    rpRepetidor.DataBind();
                }
            }
        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = ((Button)sender).CommandArgument;
                TextBox txtCantidad = (TextBox)((Button)sender).NamingContainer.FindControl("txtCantidad");

                cantidadAComprar = int.Parse(txtCantidad.Text);
                ArticulosNegocio negocio = new ArticulosNegocio();

                List<Articulo> auxArticulo = negocio.TraerListadoCompletoxId(int.Parse(valor));
                if (ArticulosCarrito == null)
                {
                    ArticulosCarrito = new List<Articulo>();
                }

                if (!negocio.revisarRepetidos(ArticulosCarrito, int.Parse(valor)) && cantidadAComprar <= auxArticulo[0].Cantidad)
                {
                    auxArticulo[0].Cantidad = cantidadAComprar;
                    ArticulosCarrito.Add(auxArticulo[0]);

                    if (idArticulo == null)
                    {
                        idArticulo = new List<int>();
                    }
                    idArticulo.Add(int.Parse(valor));
                    cantidad++;
                    negocio.restarStock(cantidadAComprar, int.Parse(valor));
                    Session.Add("ArticulosCarrito", ArticulosCarrito);
                    Session.Add("idArticulo", idArticulo);
                    Session.Add("cantidad", cantidad);
                    Session.Add("cantidadAComprar", cantidadAComprar);
                    Response.Redirect("Articulos.aspx", false);
                }
                else
                {
                    Session.Add("error", "La cantidad seleccionada es incorrecta o el producto seleccionado ya esta en tu carrito.");
                    Response.Redirect("Error.aspx", false);
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }

        }

        protected void btnLogueate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }



        
    }
}