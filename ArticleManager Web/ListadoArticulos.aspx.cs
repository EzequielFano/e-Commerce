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
            if (!IsPostBack)
            {
                ArticulosNegocio negocio = new ArticulosNegocio();

                articulos = negocio.TraerListadoCompletoSP();
                dgvArticulos.DataSource = articulos;
                dgvArticulos.DataBind();

            }

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


        protected void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            CheckBox chkStatus = (CheckBox)sender;
            bool newStatus = chkStatus.Checked;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;
          
            int idArticulo = Convert.ToInt32(dgvArticulos.DataKeys[row.RowIndex].Value);
            negocio.UpdateStatus(newStatus, idArticulo);
            Response.Redirect("ListadoArticulos.aspx");
        }
    }
}