using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArticleManager_Web
{
    public partial class Envio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnVolverFindeCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("Articulos.aspx", false);
        }
    }
}