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
    public partial class DetallesMisCompras : System.Web.UI.Page
    {
        public List<DetalleTransaccion> listaDetalles { get; set; }
        public Articulo Articulo { get; set; }
        static public int IdTransaccion { get; set; }
        static public Direccion Direccion { get; set; }
        static public Usuario Usuario { get; set; }
        static public int IdUsuario { get; set; }
        static public EstadoEnvio estado { get; set; }
        static public string Ruta { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                ArticulosNegocio negocioArticulos = new ArticulosNegocio();
                DireccionNegocio negocioDireccion = new DireccionNegocio();
                UsuarioNegocio negocioUsuario = new UsuarioNegocio();

                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                if (!IsPostBack)
                {
                    if (!String.IsNullOrEmpty(Request.QueryString["idTransaccion"]))
                    {
                        IdTransaccion = int.Parse(Request.QueryString["idTransaccion"].ToString());

                    }
                    DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
                    listaDetalles = negocioDetalles.getDetalleTransaccionListXId(IdTransaccion);

                    foreach (DetalleTransaccion aux in listaDetalles)
                    {
                        Articulo = new Articulo();
                        aux.Articulo = negocioArticulos.TraerListadoCompletoxId(aux.Articulo.IdArticulo)[0];

                    }
                    Direccion = new Direccion();
                    Direccion = negocioDireccion.DireccionSegunIdTransaccion(IdTransaccion);
                    dgvArticulosComprados.DataSource = listaDetalles;
                    dgvArticulosComprados.DataBind();
                }

            }
            else
            {
                Session.Add("error", "No tienes accesso a esta pantalla");
                Session.Add("ruta", "Articulos.aspx");
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnVolverDetallesMisCompras_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisCompras.aspx", false);
        }
    }
}
