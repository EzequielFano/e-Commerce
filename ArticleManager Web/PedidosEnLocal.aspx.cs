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
    public partial class PedidosEnLocal : System.Web.UI.Page
    {
        public List<Transaccion> Transacciones { get; set; }
        public List<Detalles> DetallesTransacciones { get; set; }
        public Direccion Direccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TransaccionNegocio negocio = new TransaccionNegocio();
                List<Transaccion> TransaccionesEnLocal = new List<Transaccion>();
                if (!IsPostBack)
                {

                    Transacciones = negocio.traerListado();
                    foreach (Transaccion aux in Transacciones)
                    {
                        if (aux.Estado == EstadoEnvio.RETIRO_EN_LOCAL)
                            TransaccionesEnLocal.Add(aux);
                    }

                    dgvPedidosEnLocal.DataSource = TransaccionesEnLocal;
                    dgvPedidosEnLocal.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        protected void dgvPedidosEnLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var id = dgvPedidosEnLocal.SelectedRow.Cells[0].Text;
                Response.Redirect("DetallesTransacciones.aspx?idTransaccion=" + id, false);
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