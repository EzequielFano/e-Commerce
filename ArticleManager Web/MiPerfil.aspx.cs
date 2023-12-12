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

        protected void Page_Load(object sender, EventArgs e)
        {
            
            UsuarioNegocio negocio = new UsuarioNegocio();
            usuario = (Usuario)Session["usuario"];
            usuario = negocio.traerUsuarioXId(usuario.IdUsuario);
            lblNombreYApellidoPerfil.Text = usuario.Nombre + " " + usuario.Apellido;
            lblIdPerfil.Text=usuario.IdUsuario.ToString();
            lblEmailPerfil.Text=usuario.Email;
            if(usuario.TipoUsuario.ToString() == "0")
            {
                lblTipoUsuarioPerfil.Text = "Cliente";
            }
            else
            {
                lblTipoUsuarioPerfil.Text = "Administrador";
            }
           
        }
    }
}