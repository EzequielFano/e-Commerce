using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class DireccionEditable : System.Web.UI.Page
    {
        public Direccion DireccionUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DireccionUsuario = (Direccion)Session["DireccionUsuario"];
                ddlProvincia.SelectedValue = DireccionUsuario.Provincia.IdProvincia.ToString();
                ddlCiudad.SelectedValue = DireccionUsuario.Ciudad.IdCiudad.ToString();
                txtCalle.Text = DireccionUsuario.Calle.ToString();
                txtNumero.Text = DireccionUsuario.Numero.ToString();
                txtDepartamento.Text = DireccionUsuario.Departamento.ToString();
                txtPiso.Text = DireccionUsuario.Piso.ToString();
            }
        }

      

        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void btnConfirmarEdicion_Click(object sender, EventArgs e)
        {

        }

        protected void btnVolverPerfil_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminarDireccion_Click(object sender, EventArgs e)
        {

        }
    }
}