﻿using Dominio;
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
        public string Ruta { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();
            ArticulosNegocio negocio = new ArticulosNegocio();
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        btnAccion.Text = "Editar articulo";
                        int id = int.Parse(Request.QueryString["id"].ToString());
                        List<Articulo> modificacion = negocio.TraerListadoCompletoxId(id);
                        txtCodigo.Text = modificacion[0].CodigoArticulo.ToString();
                        txtNombre.Text = modificacion[0].NombreArticulo.ToString();
                        txtPrecio.Text = modificacion[0].Precio.ToString();
                        txtDescripcion.Text = modificacion[0].Descripcion.ToString();
                        txtCantidad.Text = modificacion[0].Cantidad.ToString();
                        txtURLImagen.Text = modificacion[0].URLImagen.URL.ToString();
                        ddlCategoria.SelectedValue = modificacion[0].Categoria.Id.ToString();
                        ddlMarca.SelectedValue = modificacion[0].Marca.Id.ToString();

                    }
                    else
                    {
                        btnAccion.Text = "Agregar articulo";
                    }
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
            catch (Exception)
            {

                Session.Add("error", "Error inesperado al cargar los articulos");
                Session.Add("ruta", "ManipularArticulo.aspx");
                Response.Redirect("Error.aspx");
            }
        }


        protected void btnAccion_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (txtCodigo.Text.Length > 0 && txtNombre.Text.Length > 0 && txtPrecio.Text.Length > 0 && txtCantidad.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    int id = int.Parse(Request.QueryString["id"].ToString());
                    ArticulosNegocio negocio = new ArticulosNegocio();
                    articulo.IdArticulo = id;
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

                    negocio.modificarArticulo(articulo);
                    Response.Redirect("ListadoArticulos.aspx", false);

                }
                else
                {
                    Session.Add("error", "Debe completar todos los datos necesarios");
                    Session.Add("ruta", "ManipularArticulo.aspx");
                    Response.Redirect("Error.aspx", false);
                    return;
                }


            }
            else
            {
                ArticulosNegocio negocio = new ArticulosNegocio();
                if (txtCodigo.Text.Length > 0 && txtNombre.Text.Length > 0 && txtPrecio.Text.Length > 0 && txtCantidad.Text.Length > 0 && txtDescripcion.Text.Length > 0)
                {
                    articulo.CodigoArticulo = txtCodigo.Text;
                    articulo.NombreArticulo = txtNombre.Text;
                    articulo.Precio = float.Parse(txtPrecio.Text);
                    articulo.Cantidad = int.Parse(txtCantidad.Text);
                    articulo.Descripcion = txtDescripcion.Text;
                }
                else
                {
                    Session.Add("error", "Debe completar todos los datos necesarios");
                    Session.Add("ruta", "ManipularArticulo.aspx");
                    Response.Redirect("Error.aspx", false);
                    return;
                }
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
                Response.Redirect("ListadoArticulos.aspx", false);
            }
        }
    }
}