using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace ArticleManager_Web
{
    public partial class FormularioContacto : System.Web.UI.Page
    {
        public Usuario Usuario { get; set; }
        static public int IdUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.QueryString["idUsuario"]))
                {
                    IdUsuario = int.Parse(Request.QueryString["idUsuario"].ToString());
                    Usuario = new Usuario();
                    Usuario = negocioUsuario.traerUsuarioXId(IdUsuario);
                    txtNombreConsulta.Text = Usuario.Nombre;
                    txtNombreConsulta.Enabled = false;
                    txtEmailConsulta.Text = Usuario.Email;
                    txtEmailConsulta.Enabled = false;
                }
                else
                {
                    txtNombreConsulta.Enabled = true;
                    txtEmailConsulta.Enabled = true;
                }

            }



        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.EmailConsulta(txtNombreConsulta.Text, txtEmailConsulta.Text, txtConsulta.Text);
            if (!String.IsNullOrEmpty(Request.QueryString["idUsuario"]))
            {
                Response.Redirect("DetallesTransacciones.aspx", false);
            }
            else
            {
                Response.Redirect("Articulos.aspx", false);
            }
        }
    }
}