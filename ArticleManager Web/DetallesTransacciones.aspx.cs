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

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArticulos = new ArticulosNegocio();
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["idTransaccion"].ToString());
                DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
                listaDetalles = negocioDetalles.getDetalleTransaccionListXId(id);

                foreach (DetalleTransaccion aux in listaDetalles)
                {
                    Articulo = new Articulo();
                    aux.Articulo = negocioArticulos.TraerListadoCompletoxId(aux.Articulo.IdArticulo)[0];
                }
                dgvArticulosComprados.DataSource = listaDetalles;
                dgvArticulosComprados.DataBind();

            }

        }
    }
}