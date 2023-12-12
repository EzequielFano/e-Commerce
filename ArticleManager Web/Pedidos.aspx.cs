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

            if ((Usuario)Session["usuario"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["usuario"];
                if (usuario.TipoUsuario == TipoUsuario.Admin)
                {
                    try
                    {
                        TransaccionNegocio negocio = new TransaccionNegocio();
                        List<Transaccion> TransaccionesIniciadas = new List<Transaccion>();
                        DireccionNegocio negocioDireccion = new DireccionNegocio();
                        if (!IsPostBack)
                        {
                            Transacciones = negocio.traerListado();
                            foreach (Transaccion aux in Transacciones)
                            {
                                if (aux.Estado == EstadoEnvio.INICIADO)
                                {
                                    TransaccionesIniciadas.Add(aux);
                                    //aux.Direccion = negocioDireccion.DireccionSegunIdTransaccion(aux.IdTransaccion);
                                }
                            }
                            dgvPedidos.DataSource = TransaccionesIniciadas;
                            dgvPedidos.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
                else
                {
                    Session.Add("error", "No tienes accesso a esta pantalla");
                    Session.Add("ruta", "Articulos.aspx");
                    Response.Redirect("Error.aspx");
                }

                }
                else
                {
                    Session.Add("error", "No tienes accesso a esta pantalla");
                    Session.Add("ruta", "Articulos.aspx");
                    Response.Redirect("Error.aspx");
                }
            }
            protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    var idTransaccion = dgvPedidos.SelectedRow.Cells[0].Text;
                    var idUsuario = dgvPedidos.SelectedRow.Cells[1].Text;
                    var idOpcionEnvio = dgvPedidos.SelectedRow.Cells[3].Text;
                    var EstadoEnvio = dgvPedidos.SelectedRow.Cells[7].Text;
                    Response.Redirect($"DetallesTransacciones.aspx?idTransaccion={idTransaccion}&idUsuario={idUsuario}&idOpcionEnvio={idOpcionEnvio}&EstadoEnvio={EstadoEnvio}", false);
                    Session.Add("ruta", "Pedidos.aspx");
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