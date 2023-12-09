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
        public Articulo Articulo { get; set; }
        public int IdTransaccion { get; set; }
        public Direccion Direccion { get; set; }
        public Usuario Usuario { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArticulos = new ArticulosNegocio();
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();

            if (!IsPostBack)
            {
                int IdTransaccion = int.Parse(Request.QueryString["idTransaccion"].ToString());
                int IdUsuario = int.Parse(Request.QueryString["idUsuario"].ToString());
                DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
                listaDetalles = negocioDetalles.getDetalleTransaccionListXId(IdTransaccion);

                foreach (DetalleTransaccion aux in listaDetalles)
                {
                    Articulo = new Articulo();
                    aux.Articulo = negocioArticulos.TraerListadoCompletoxId(aux.Articulo.IdArticulo)[0];
                }
                Direccion = new Direccion();
                Direccion = negocioDireccion.DireccionSegunIdTransaccion(IdTransaccion);
                Usuario = new Usuario();
                Usuario = negocioUsuario.traerUsuarioXId(IdUsuario);
                dgvArticulosComprados.DataSource = listaDetalles;
                dgvArticulosComprados.DataBind();

            }

        }
    }
}