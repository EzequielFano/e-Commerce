using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace ArticleManager_Web
{
    public partial class Pago : System.Web.UI.Page
    {
        static public List<Articulo> ArticulosComprados { get; set; }
        static public List<Articulo> ArticulosCarrito { get; set; }
        static public int CantidadEnCarrito { get; set; }
        static public float PrecioTotal { get; set; }
        static public Usuario Usuario { get; set; }
        static public Direccion Direccion { get; set; }
        public Provincia Provincia { get; set; }
        public Ciudad Ciudad { get; set; }
        static public List<DetalleTransaccion> Detalles { get; set; }
        static public Transaccion Transaccion { get; set; }
        static public int TipoPago { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ProvinciaNegocio negocio = new ProvinciaNegocio();

            if (!IsPostBack)
            {
                ArticulosCarrito = (List<Articulo>)Session["ArticulosCarrito"];
                CantidadEnCarrito = Session["CantidadEnCarrito"] != null ? (int)Session["CantidadEnCarrito"] : 0;
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
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            EmailService emailService = new EmailService();
            //int IdTransaccion = 0;
            try
            {
                Direccion = new Direccion();
                Direccion.Provincia = new Provincia();
                Direccion.Ciudad = new Ciudad();
                if (string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
                {
                    Session.Add("error", "Por favor seleccione un metodo de pago, reintente realizar la compra");
                    Session.Add("ruta", "Pago.aspx");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
                TipoPago = int.Parse(ddlMetodoPago.SelectedItem.Value);
                if (string.IsNullOrEmpty(ddlOpcionesEnvio.SelectedItem.Value))
                {
                    Session.Add("error", "Por favor seleccione una opcion de envio, reintente realizar la compra");
                    Session.Add("ruta", "Pago.aspx");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
                int RetiroEnLocal = int.Parse(ddlOpcionesEnvio.SelectedItem.Value);

                if (RetiroEnLocal == 1)
                {

                    if (string.IsNullOrEmpty(ddlProvincia.SelectedItem.Value))
                    {
                        Session.Add("error", "Debe seleccionar una provincia, reintente realizar la compra");
                        Session.Add("ruta", "Pago.aspx");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    Direccion.Provincia.IdProvincia = int.Parse(ddlProvincia.SelectedItem.Value);
                    if (string.IsNullOrEmpty(ddlCiudad.SelectedItem.Value))
                    {
                        Session.Add("error", "Debe seleccionar una ciudad, reintente realizar la compra");
                        Session.Add("ruta", "Pago.aspx");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    Direccion.Ciudad.IdCiudad = int.Parse(ddlCiudad.SelectedItem.Value);
                    if (txtCalle.Text == "")
                    {
                        Session.Add("error", "Debe introducir una calle valida, reintente realizar la compra");
                        Session.Add("ruta", "Pago.aspx");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    Direccion.Calle = txtCalle.Text;
                    if (txtNumero.Text == "")
                    {
                        Session.Add("error", "Debe introducir una altura valida, reintente realizar la compra");
                        Session.Add("ruta", "Pago.aspx");
                        Response.Redirect("Error.aspx", false);
                        return;
                    }
                    Direccion.Numero = int.Parse(txtNumero.Text);
                    Direccion.Departamento = txtDepartamento.Text;
                    if (txtPiso.Text == "")
                    {
                        Direccion.Piso = 0;
                    }
                    else
                    {
                        Direccion.Piso = int.Parse(txtPiso.Text);
                    }
                }
                int IdTransaccion = negocioTransaccion.generarTransaccion(Usuario, RetiroEnLocal, DateTime.Now, TipoPago, PrecioTotal);
                foreach (Articulo aux in ArticulosComprados)
                {
                    negocioDetalles.generarDetallesTransaccion(aux, IdTransaccion);
                }
                if (chkDireccion.Checked || RetiroEnLocal != 2)
                {
                    negocioDireccion.generarDireccion(Direccion, IdTransaccion, Usuario.IdUsuario);
                }

                emailService.EmailCompra(Usuario.Email, IdTransaccion, Usuario.Nombre);
                ArticulosCarrito.Clear();
                CantidadEnCarrito = 0;
                Session.Add("CantidadEnCarrito", CantidadEnCarrito);

            }
            catch (Exception)
            {

                Session.Add("error", "Error inesperado al intentar realizar la compra");
                Session.Add("ruta", "Pago.aspx");
                Response.Redirect("Error.aspx", false);
                return;
            }

            Response.Redirect("Envio.aspx");
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CiudadNegocio negocio = new CiudadNegocio();
            ddlCiudad.DataSource = negocio.listarXIdDeProvincia(int.Parse(ddlProvincia.SelectedItem.Value));
            ddlCiudad.DataTextField = "Nombre";
            ddlCiudad.DataValueField = "IdCiudad";
            ddlCiudad.DataBind();
        }

        protected void btnVolverPago_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito.aspx", false);
        }

        protected void ddlOpcionesEnvio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(ddlOpcionesEnvio.SelectedItem.Value) == 2)
            {
                ddlProvincia.Enabled = false;
                ddlCiudad.Enabled = false;
                txtCalle.Enabled = false;
                txtNumero.Enabled = false;
                txtDepartamento.Enabled = false;
                txtPiso.Enabled = false;
                chkDireccion.Enabled = false;
            }
            else
            {
                ddlProvincia.Enabled = true;
                ddlCiudad.Enabled = true;
                txtCalle.Enabled = true;
                txtNumero.Enabled = true;
                txtDepartamento.Enabled = true;
                txtPiso.Enabled = true;
                chkDireccion.Enabled = true;
            }
        }
    }
}
