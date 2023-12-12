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
    public partial class CrearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            bool existEenDB = negocio.existeMailenDB(txtEmail.Text);
            if (!existEenDB)
            {
                if (txtEmail.Text != "" && txtNombre.Text != "" && txtContra.Text != "" && txtApellido.Text != "")
                {
                    Usuario usuario = new Usuario(txtEmail.Text, txtNombre.Text, txtContra.Text, false);
                    usuario.Apellido = txtApellido.Text;
                    negocio.crearUsuario(usuario);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Session.Add("error", "Debes ingresar todos los datos para registrarte");
                    Session.Add("ruta", "CrearCuenta.aspx");
                    Response.Redirect("Error.aspx", false);
                }
            }
            else
            {
                Session.Add("error", "El mail ya se encuentra registrado");
                Session.Add("ruta", "CrearCuenta.aspx");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}