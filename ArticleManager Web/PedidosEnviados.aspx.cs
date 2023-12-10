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
    public partial class PedidosEnviados : System.Web.UI.Page
    {
        public List<Transaccion> Transacciones { get; set; }
        public List<Detalles> DetallesTransacciones { get; set; }
        public Direccion Direccion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TransaccionNegocio negocio = new TransaccionNegocio();
                List<Transaccion> TransaccionesEnviadas = new List<Transaccion>();

                if (!IsPostBack)
                {

                    Transacciones = negocio.traerListado();
                    foreach (Transaccion aux in Transacciones)
                    {
                        if (aux.Estado == EstadoEnvio.EN_PROCESO)
                            TransaccionesEnviadas.Add(aux);
                    }
                    dgvPedidosEnviados.DataSource = TransaccionesEnviadas;
                    dgvPedidosEnviados.DataBind();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void dgvPedidosEnviados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var idTransaccion = dgvPedidosEnviados.SelectedRow.Cells[0].Text;
                var idUsuario = dgvPedidosEnviados.SelectedRow.Cells[1].Text;
                var idOpcionEnvio = dgvPedidosEnviados.SelectedRow.Cells[3].Text;
                var EstadoEnvio = dgvPedidosEnviados.SelectedRow.Cells[7].Text;
                Response.Redirect($"DetallesTransacciones.aspx?idTransaccion={idTransaccion}&idUsuario={idUsuario}&idOpcionEnvio={idOpcionEnvio}&EstadoEnvio={EstadoEnvio}", false);
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