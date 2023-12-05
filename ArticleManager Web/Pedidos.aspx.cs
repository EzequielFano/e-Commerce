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
    public partial class Pedidos : System.Web.UI.Page
    {
        public List<Transaccion> Transacciones { get; set; }
        public List<Detalles> DetallesTransacciones { get; set; }
        public Direccion Direccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
			try
			{
                TransaccionNegocio negocio = new TransaccionNegocio();
                if (!IsPostBack)
                {
                    Transacciones = negocio.traerListado();
                    dgvPedidos.DataSource = Transacciones;
                    dgvPedidos.DataBind();
                }
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvPedidos.SelectedRow.Cells[0].Text;
                Response.Redirect("DetallesTransacciones.aspx?idTransaccion=" + id);
            }
            catch (Exception)
            {

                Session.Add("error", "Error al cargar los pedidos");
                Session.Add("ruta", "Pedidos.aspx");
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}