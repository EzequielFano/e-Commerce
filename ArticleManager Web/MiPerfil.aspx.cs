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
    public partial class MiPerfil : System.Web.UI.Page
    {
        static public Usuario usuario { get; set; }
        public bool edit { get; set; }

        public Direccion DireccionUsuario { get; set; }



        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Usuario)Session["usuario"] != null)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                DireccionNegocio direccionNegocio = new DireccionNegocio();
                usuario = (Usuario)Session["usuario"];
                usuario = negocio.traerUsuarioXId(usuario.IdUsuario);
                DireccionUsuario = direccionNegocio.obtenerDireccionDelUsuario(usuario.IdUsuario);
                lblNombreYApellidoPerfil.Text = usuario.Nombre + " " + usuario.Apellido;
                lblIdPerfil.Text = usuario.IdUsuario.ToString();
                lblEmailPerfil.Text = usuario.Email;
                if (DireccionUsuario.IdDireccion != 0)
                {
                    lblDireccionUsuario.Text = DireccionUsuario.Calle + " " + DireccionUsuario.Numero;
                }
                else
                {
                    lblDireccionUsuario.Text = "No hay una direccion cargada.";
                }

                if (usuario.TipoUsuario == TipoUsuario.Cliente)
                {
                    lblTipoUsuarioPerfil.Text = "Cliente";
                }
                else
                {
                    lblTipoUsuarioPerfil.Text = "Administrador";
                }
            }
            else
            {
                Session.Add("error", "No puedes ingresar al perfil sin iniciar sesion");
                Session.Add("ruta", "Articulos.aspx");
                Response.Redirect("Error.aspx");
            }

        }
        protected void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfilEditable.aspx", false);
        }

        protected void btnVolverPerfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx", false);
        }

        protected void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            Session.Add("DireccionUsuario", DireccionUsuario);
            Response.Redirect("DireccionEditable.aspx", false);
        }
    }
}