using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ArticleManager_Web.Articulos1;



namespace ArticleManager_Web
{
    public partial class Login : System.Web.UI.Page
    {
        public string user { get; set; }
        public string password { get; set; }
        public bool session { get; set; }
        static public int CantidadEnCarrito { get; set; }
        static public List<Articulo> ArticulosCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                session = Session["session"] != null ? (bool)Session["session"] : false;
                ArticulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
                CantidadEnCarrito = Session["CantidadEnCarrito"] != null ? (int)Session["CantidadEnCarrito"] : 0;
                lblUser.Text = user;

            }




        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();
            if (ArticulosCarrito == null)
            {
                ArticulosCarrito = new List<Articulo>();
            }

            foreach (Articulo aux in ArticulosCarrito)
            {
                negocio.sumarStock(aux.Cantidad, aux.IdArticulo);
            }
            ArticulosCarrito.Clear();
            CantidadEnCarrito = 0;
            Session.Add("CantidadEnCarrito", CantidadEnCarrito);
            Session.Remove("usuario");
            Session.Add("session", session);
            Session.Add("session", false);
            Session.Add("TipoUsuario", 1);
            Response.Redirect("Login.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx", false);
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            Usuario usuario;
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                usuario = new Usuario(txtUser.Text, txtUser.Text, txtPassword.Text, false);
                if (negocio.Loguear(usuario))
                {
                    Session.Add("usuario", usuario);
                    Session.Add("session", true);
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Session.Add("error", "Email o contraseña incorrectos");
                    Session.Add("ruta", "Login.aspx");
                    Session.Add("session", false);
                    Response.Redirect("Error.aspx");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        protected void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("CrearCuenta.aspx");
        }
    }

}