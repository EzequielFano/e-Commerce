using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class Error : System.Web.UI.Page
    {
       public string Ruta {  get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["error"]!= null)
            {
                Ruta = Session["ruta"].ToString();
                lblMensajeError.Text = Session["error"].ToString();
            }
        }
    }
}