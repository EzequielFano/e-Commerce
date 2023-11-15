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
    public partial class ManipularArticulo : System.Web.UI.Page
    {
        Articulo articulo = new Articulo();

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            try
            {
                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = categoria.listar();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlMarca.DataSource = marca.listar();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            articulo.CodigoArticulo = txtCodigo.Text;
            articulo.NombreArticulo = txtNombre.Text;
            articulo.Precio = float.Parse(txtPrecio.Text);
            articulo.Cantidad = int.Parse(txtCantidad.Text);
            articulo.Descripcion = txtDescripcion.Text;
            articulo.Marca = new Marca();
            articulo.Marca.Id = int.Parse(ddlMarca.SelectedItem.Value);
            articulo.Categoria = new Categoria();
            articulo.Categoria.Id = int.Parse(ddlCategoria.SelectedItem.Value);
            articulo.URLImagen = new Imagen();
            if (txtURLImagen.Text == null)
            {
                articulo.URLImagen.URL = " ";
            }
            articulo.URLImagen.URL = txtURLImagen.Text;
           
            negocio.agregarArticulo(articulo);
            Response.Redirect("Articulos.aspx");

        }
    }
}