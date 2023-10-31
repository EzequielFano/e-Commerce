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
    public partial class MiMaster : System.Web.UI.MasterPage
    {
        public bool session { get; set; }
        public int cantidadCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            session = Session["session"] != null ? (bool)Session["session"] : false;
            cantidadCarrito = Session["cantidad"] != null ? (int)Session["cantidad"] : 0;
        }

        
    }
}