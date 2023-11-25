using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace ArticleManager_Web
{
    public partial class Pago : System.Web.UI.Page
    {
        public List<Articulo> ArticulosComprados { get; set; }
        public float PrecioTotal { get; set; }
        public Usuario Usuario { get; set; }
        public Direccion Direccion { get; set; }
        public List<DetalleTransaccion> Detalles { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();
            CiudadNegocio negocioCiudad = new CiudadNegocio();
            List<Provincia> ListaProvincias = new List<Provincia>();
            if (!IsPostBack)
            {
                ArticulosComprados = (List<Articulo>)Session["ArticulosCarrito"];
                Usuario = (Usuario)Session["usuario"];
                PrecioTotal = 0;
                foreach (Articulo articulo in ArticulosComprados)
                {
                    PrecioTotal += (articulo.Precio * articulo.Cantidad);
                }
                dgvArticulosComprados.DataSource = ArticulosComprados;
                dgvArticulosComprados.DataBind();
                ddlProvincia.DataSource = negocio.listarProvincias();
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();
            }

        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Envio.aspx");
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CiudadNegocio negocio = new CiudadNegocio();
            ddlCiudad.DataSource = negocio.listarXIdDeProvincia(int.Parse(ddlProvincia.SelectedItem.Value));
            ddlProvincia.DataTextField = "Nombre";
            ddlProvincia.DataValueField = "IdCiudad";
            ddlCiudad.DataBind();
        }
    }
}