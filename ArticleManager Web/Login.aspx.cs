using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class Login : System.Web.UI.Page
    {
        public string user { get; set; }
        public string password { get; set; }
        public bool session { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {           
            
            user = Session["user"]!=null ? Session["user"].ToString() : "" ;  
            password = Session["password"] != null ? Session["user"].ToString() : "";
            session = Session["session"] != null ? (bool)Session["session"] : false;
            lblUser.Text = user;
            
           
           

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text !="" && txtPassword.Text !="")
            {
            user = txtUser.Text;
            password = txtPassword.Text;  
            Session.Add("user", user);
            Session.Add("password", password);
            Session.Add("session", true);        
            Response.Redirect("Login.aspx", false);

            }
            else
            {

                user = "";
                password = "";
                Session.Add("user", user);
                Session.Add("password", password);
                Session.Add("session", false);                
                Response.Redirect("Login.aspx", false);

            }

        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            
            Session.Add("user", "");
            Session.Add("password", "");
            Session.Add("session", session);
            Session.Add("session", false);
            Response.Redirect("Login.aspx", false);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx", false);
        }
    }
}