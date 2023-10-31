using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Runtime.InteropServices;
using System.Web.DynamicData;

namespace ArticleManager_Web
{
    public partial class Detalles : System.Web.UI.Page
    {
        public List<Imagen> ListaImagenes { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticulosNegocio negocio = new ArticulosNegocio();

            string id = Request.QueryString["id"];
            rpDetalles.DataSource = negocio.verDetallesArticulo(int.Parse(id));
            rpDetalles.DataBind();
        

            ListaImagenes = negocio.verImagenesArticulo(int.Parse(id));
            rpRepetidorImg.DataSource = ListaImagenes;
            rpRepetidorImg.DataBind();
            
        }
    }
}