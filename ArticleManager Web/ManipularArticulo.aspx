<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ManipularArticulo.aspx.cs" Inherits="ArticleManager_Web.ManipularArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-label {
            color: rebeccapurple;
            font-weight: bold;
        }

        .custom-form {
            margin-top: 50px;
        }      

        #carouselExample {
            width: 50%;
            margin-top: 20px;
        }

            #carouselExample img {
                width: 100%;
                height: auto;
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
            <asp:Button  CssClass="btn btn-success" ID="btnAccion" OnClick="btnAccion_Click" runat="server" />
        </div>
        

        <!-- IMAGENES-->
        <div id="carouselExample" class="carousel slide">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="<%=txtURLImagen%>" class="d-block w-100" alt="...">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </div>
</asp:Content>
