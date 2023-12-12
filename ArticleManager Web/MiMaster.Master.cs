using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        public bool session { get; set; }
        public bool admin { get; set; }
        public int CantidadEnCarrito { get; set; }
        static public bool filtrado { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                session = Session["session"] != null ? (bool)Session["session"] : false;
                CantidadEnCarrito = Session["CantidadEnCarrito"] != null ? (int)Session["CantidadEnCarrito"] : 0;
            }
        }
      
        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
      
            ArticulosNegocio negocio = new ArticulosNegocio();
            List<Articulo> lista = new List<Articulo>();
            List<Articulo> auxArticulo = negocio.TraerListadoSP();
            string busqueda = txtBuscador.Text;
            if (busqueda.Length > 0)
            {
                lista = auxArticulo.FindAll(x => x.NombreArticulo.ToUpper().Contains(busqueda.ToUpper())
                || x.CodigoArticulo.ToUpper().Contains(busqueda.ToUpper())
                || x.Descripcion.ToUpper().Contains(busqueda.ToUpper())
                || x.Marca.Descripcion.ToUpper().Contains(busqueda.ToUpper())
                || x.Categoria.Descripcion.ToUpper().Contains(busqueda.ToUpper()));
            }
            else
            {
                lista = auxArticulo;
            }
            filtrado = true;

            ListaArticulos = lista;
            Session.Add("Filtrado", filtrado);
            Session.Add("ListaArticulos", ListaArticulos);
            Response.Redirect("Articulos.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            
            ArticulosNegocio negocio = new ArticulosNegocio();
            List<Articulo> lista = new List<Articulo>();
            List<Articulo> auxArticulo = negocio.TraerListadoSP();
            lista = auxArticulo;
            filtrado = false;
            ListaArticulos = lista;
            Session.Add("Filtrado", filtrado);
            Session.Add("ListaArticulos", ListaArticulos);
            Response.Redirect("Articulos.aspx", false);
        }        
    }
}