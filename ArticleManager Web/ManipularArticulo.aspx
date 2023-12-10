<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ManipularArticulo.aspx.cs" Inherits="ArticleManager_Web.ManipularArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-label {
            color: rebeccapurple;
            font-weight: bold;
        }

        .custom-form {
            margin-top: 50px;
            margin-left: auto;
            margin-right: auto;
            max-width: 600px; /* Ajusta según sea necesario */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container custom-form">

        <div class="col-6 mb-3">
            <label for="inputNombre" class="form-label">Nombre:</label>
            <div class="input-group">
                <span class="input-group-text">ID </span>
                <asp:TextBox type="text" placeholder="Nombre" CssClass="form-control" ID="txtNombre" runat="server" />
                <asp:TextBox type="text" placeholder="Codigo" CssClass="form-control" ID="txtCodigo" runat="server" />
            </div>
        </div>
        <div class="col-3 mb-3">
            <label for="inputAddress2" class="form-label">Precio:</label>
            <div class="input-group">
                <span class="input-group-text">$</span>
                <asp:TextBox type="text" placeholder="Ingresar precio..." CssClass="form-control" ID="txtPrecio" runat="server" />
            </div>
        </div>
        <div class="col-3 mb-3">
            <label for="inputAddress2" class="form-label">Cantidad:</label>
            <asp:TextBox type="text" placeholder="Ingresar precio.." CssClass="form-control" ID="txtCantidad" runat="server" />
        </div>
        <div class="col-6 mb-3">
            <label for="inputAddress" class="form-label">Descripcion:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox>
        </div>

        <div class="col-md-3 mb-3">
            <label for="inputStatee" class="form-label">Categoria</label>
            <asp:DropDownList ID="ddlCategoria" PlaceHolder="Seleccionar.." CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="col-md-3 mb-3">
            <label for="inputState" class="form-label">Marca</label>
            <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
        </div>
        <div class="col-6 mb-3">
            <label for="inputAddress2" class="form-label">Imagen:</label>
            <div class="input-group">
                <span class="input-group-text">URL</span>
                <asp:TextBox type="text" CssClass="form-control" ID="txtURLImagen" runat="server" />
            </div>
        </div>
        <div class="col-12 mb-3">
            <asp:Button CssClass="btn btn-success" ID="btnAccion" OnClick="btnAccion_Click" runat="server" />
        </div>
        <div>
            <%if (Request.QueryString["id"] != null)
                { %>
            <br />
            <a href="<%=Ruta %>" class="btn btn-outline-light" style="display: block; margin: 0 auto; text-align: center; color: violet; max-width: 10%">Volver</a>
            <br />
            <%} %>
        </div>
    </div>
</asp:Content>
