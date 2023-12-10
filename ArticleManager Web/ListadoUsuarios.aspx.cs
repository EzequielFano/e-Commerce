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
    public partial class ListadoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();   
            if (!IsPostBack)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();

                usuarios = negocio.listarUsuarios();
                dgvUsuarios.DataSource = usuarios;
                dgvUsuarios.DataBind();

            }
        }

        protected void dgvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            CheckBox chkStatus = (CheckBox)sender;
            bool newStatus = chkStatus.Checked;
            GridViewRow row = (GridViewRow)chkStatus.NamingContainer;

            int idArticulo = Convert.ToInt32(dgvUsuarios.DataKeys[row.RowIndex].Value);
            negocio.UpdateStatusUsuario(newStatus, idArticulo);
            Response.Redirect("ListadoUsuarios.aspx");
        }
    }
}