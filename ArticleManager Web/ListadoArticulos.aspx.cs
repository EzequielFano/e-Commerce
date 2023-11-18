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
    public partial class ListadoArticulos : System.Web.UI.Page
    {
        List<Articulo> articulos = new List<Articulo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            articulos = negocio.TraerListadoCompletoSP();

            dgvArticulos.DataSource = articulos;
            dgvArticulos.DataBind();

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvArticulos.SelectedRow.Cells[0].Text;
                Response.Redirect("ManipularArticulo.aspx?id=" + id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        protected string GetStatusColor(object status)
        {
            if (status != null && status.ToString() == "1")
            {
                return "green-text"; // Clase de estilo para texto verde
            }
            else
            {
                return "red-text"; // Clase de estilo para texto rojo
            }
        }

    }
}