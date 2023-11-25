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
        public Transaccion Transaccion { get; set; }
        public int TipoPago { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();

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
            DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
            TransaccionNegocio negocioTransaccion = new TransaccionNegocio();

            int IdTransaccion = negocioTransaccion.cantidadTransacciones();

            foreach (Articulo aux in ArticulosComprados)
            {
                negocioDetalles.generarDetallesTransaccion(aux, IdTransaccion);
            }
            Direccion = new Direccion();
            Direccion.Provincia.IdProvincia = int.Parse(ddlProvincia.SelectedItem.Value);
            Direccion.Ciudad.IdCiudad = int.Parse(ddlCiudad.SelectedItem.Value);
            Direccion.Calle = txtCalle.Text;
            Direccion.Numero = int.Parse(txtNumero.Text);
            Direccion.Departamento = txtDepartamento.Text;
            Direccion.Piso = int.Parse(txtPiso.Text);
            TipoPago = int.Parse(ddlMetodoPago.SelectedItem.Value);
            //Falta fecha


            //public int IdTransaccion { get; set; }
            //public Usuario User { get; set; }
            //public List<DetalleTransaccion> DetalleTransacciones { get; set; }
            //public DateTime FechaTransaccion { get; set; }
            //public Direccion Direccion { get; set; }
            //public float Importe { get; set; }
            //public string NroSeguimiento { get; set; }
            //public int MyProperty { get; set; }
            //public int Estado { get; set; }
            //public TipoPago TipoPago { get; set; }





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