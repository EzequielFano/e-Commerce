using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace ArticleManager_Web
{
    public partial class DetallesTransacciones : System.Web.UI.Page
    {
        public List<DetalleTransaccion> listaDetalles { get; set; }
        public Articulo Articulo { get; set; }
        static public int IdTransaccion { get; set; }
        static public Direccion Direccion { get; set; }
        static public Usuario Usuario { get; set; }
        static public int IdUsuario { get; set; }
        static public int OpcionEnvio { get; set; }
        static public EstadoEnvio estado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio negocioArticulos = new ArticulosNegocio();
            DireccionNegocio negocioDireccion = new DireccionNegocio();
            UsuarioNegocio negocioUsuario = new UsuarioNegocio();

            if (!IsPostBack)
            {
                IdTransaccion = int.Parse(Request.QueryString["idTransaccion"].ToString());
                IdUsuario = int.Parse(Request.QueryString["idUsuario"].ToString());
                OpcionEnvio = int.Parse(Request.QueryString["idOpcionEnvio"].ToString());
                estado = (EstadoEnvio)Enum.Parse(typeof(EstadoEnvio), Request.QueryString["EstadoEnvio"].ToString());
                DetalleTransaccionNegocio negocioDetalles = new DetalleTransaccionNegocio();
                listaDetalles = negocioDetalles.getDetalleTransaccionListXId(IdTransaccion);

                foreach (DetalleTransaccion aux in listaDetalles)
                {
                    Articulo = new Articulo();
                    aux.Articulo = negocioArticulos.TraerListadoCompletoxId(aux.Articulo.IdArticulo)[0];
                }
                Direccion = new Direccion();
                Direccion = negocioDireccion.DireccionSegunIdTransaccion(IdTransaccion);
                Usuario = new Usuario();
                Usuario = negocioUsuario.traerUsuarioXId(IdUsuario);
                dgvArticulosComprados.DataSource = listaDetalles;
                dgvArticulosComprados.DataBind();
                if (estado == EstadoEnvio.INICIADO)
                {
                    btnCambiarEstado.Text = "COMENZAR TRANSACCION";
                }
                else if (estado == EstadoEnvio.EN_PROCESO)
                {
                    btnCambiarEstado.Text = "CLIENTE PAGÓ";
                }
                else if (estado == EstadoEnvio.PAGADO)
                {
                    btnCambiarEstado.Text = "PEDIDO ENTREGADO";
                }


            }

        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            TransaccionNegocio negocioTransaccion = new TransaccionNegocio();

            if (estado == EstadoEnvio.INICIADO)
            {
                negocioTransaccion.cambiarEstadoTransaccion(2, IdTransaccion);

                Response.Redirect("Pedidos.aspx", false);
            }
            else if (estado == EstadoEnvio.EN_PROCESO)
            {
                negocioTransaccion.cambiarEstadoTransaccion(3, IdTransaccion);
                Response.Redirect("PedidosEnviados.aspx", false);
            }
            else if (estado == EstadoEnvio.PAGADO)
            {
                negocioTransaccion.cambiarEstadoTransaccion(4, IdTransaccion);
                Response.Redirect("PedidosPagados.aspx", false);
            }

        }

        protected void btnEnviarMail_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioContacto.aspx?IdUsuario=" + IdUsuario);
        }
    }
}