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
    public partial class MiPerfilEditable : System.Web.UI.Page
    {
        static public Usuario usuario { get; set; }
        public bool edit { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
            UsuarioNegocio negocio = new UsuarioNegocio();
            usuario = (Usuario)Session["usuario"];
            usuario = negocio.traerUsuarioXId(usuario.IdUsuario);
            txtNombreEditable.Text = usuario.Nombre;
            txtApellidoEditable.Text = usuario.Apellido;
            txtIdPerfilEditable.Text = usuario.IdUsuario.ToString();
            txtIdPerfilEditable.Enabled = false;
            txtEmailPerfilEditable.Text = usuario.Email;
            if (usuario.TipoUsuario == TipoUsuario.Cliente)
            {
                txtTipoUsuarioPerfilEditable.Text = "Cliente";
                
            }
            else
            {
                txtTipoUsuarioPerfilEditable.Text = "Administrador";
            }
            txtTipoUsuarioPerfilEditable.Enabled = false;
            }
        }

        protected void btnVolverPerfilEditable_Click(object sender, EventArgs e)
        {
            Response.Redirect("MiPerfil.aspx", false);
        }

        protected void btnEditarPerfilEditable_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario aux = new Usuario();
            usuario = (Usuario)Session["usuario"];
            usuario = negocio.traerUsuarioXId(usuario.IdUsuario);
            aux.IdUsuario = usuario.IdUsuario ;
            aux.Nombre = txtNombreEditable.Text;
            aux.Apellido = txtApellidoEditable.Text;
            aux.Email = txtEmailPerfilEditable.Text;
            aux.Password = usuario.Password;
            aux.TipoUsuario = usuario.TipoUsuario;
            aux.Status = usuario.Status;
            negocio.EditarUsuario(aux);
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}