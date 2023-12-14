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
    public partial class DireccionEditable : System.Web.UI.Page
    {
        static public Direccion DireccionUsuario { get; set; }
        static public int IdUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();

            if (!IsPostBack)
            {
                IdUsuario = (int)Session["IdUsuario"];
                DireccionUsuario = (Direccion)Session["DireccionUsuario"];
                ddlProvincia.SelectedValue = DireccionUsuario.Provincia.IdProvincia.ToString();
                ddlCiudad.SelectedValue = DireccionUsuario.Ciudad.IdCiudad.ToString();
                txtCalle.Text = DireccionUsuario.Calle.ToString();
                txtNumero.Text = DireccionUsuario.Numero.ToString();
                txtDepartamento.Text = DireccionUsuario.Departamento.ToString();
                txtPiso.Text = DireccionUsuario.Piso.ToString();
                ddlProvincia.DataSource = negocio.listarProvincias();
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();
                ddlProvincia_SelectedIndexChanged1(sender, e);
            }
        }



        protected void ddlProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            CiudadNegocio negocio = new CiudadNegocio();
            ddlCiudad.DataSource = negocio.listarXIdDeProvincia(int.Parse(ddlProvincia.SelectedItem.Value));
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataValueField = "IdCiudad";
            ddlCiudad.DataBind();
        }

        protected void btnConfirmarEdicion_Click(object sender, EventArgs e)
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();

            if (string.IsNullOrEmpty(ddlProvincia.SelectedItem.Value))
            {
                Session.Add("error", "Debe seleccionar una provincia, reintente realizar la compra");
                Session.Add("ruta", "DireccionEditable.aspx");
                Response.Redirect("Error.aspx", false);
                return;
            }
            DireccionUsuario.Provincia.IdProvincia = int.Parse(ddlProvincia.SelectedItem.Value);
            if (string.IsNullOrEmpty(ddlCiudad.SelectedItem.Value))
            {
                Session.Add("error", "Debe seleccionar una ciudad, reintente realizar la compra");
                Session.Add("ruta", "DireccionEditable.aspx");
                Response.Redirect("Error.aspx", false);
                return;
            }
            DireccionUsuario.Ciudad.IdCiudad = int.Parse(ddlCiudad.SelectedItem.Value);
            if (txtCalle.Text == "")
            {
                Session.Add("error", "Debe introducir una calle valida, reintente realizar la compra");
                Session.Add("ruta", "DireccionEditable.aspx");
                Response.Redirect("Error.aspx", false);
                return;
            }
            DireccionUsuario.Calle = txtCalle.Text;
            if (txtNumero.Text == "")
            {
                Session.Add("error", "Debe introducir una altura valida, reintente realizar la compra");
                Session.Add("ruta", "DireccionEditable.aspx");
                Response.Redirect("Error.aspx", false);
                return;
            }
            DireccionUsuario.Numero = int.Parse(txtNumero.Text);
            DireccionUsuario.Departamento = txtDepartamento.Text;
            if (txtPiso.Text == "")
            {
                DireccionUsuario.Piso = 0;
            }
            else
            {
                DireccionUsuario.Piso = int.Parse(txtPiso.Text);
            }



            direccionNegocio.modificarDireccionDeUsuario(DireccionUsuario, IdUsuario);
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnVolverPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnEliminarDireccion_Click(object sender, EventArgs e)
        {
            DireccionNegocio direccionNegocio = new DireccionNegocio();
            direccionNegocio.eliminarDireccionUsuario(DireccionUsuario.IdDireccion);
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}