<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ManipularArticulo.aspx.cs" Inherits="ArticleManager_Web.ManipularArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Estilo para las etiquetas label */
        .form-label {
            color: violet;
            font-weight: bold;
        }

        /* Ajuste de margen superior para el formulario */
        .custom-form {
            margin-top: 200px; /* Puedes ajustar este valor según tus necesidades */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="row g-3 custom-form">
        <div class="col-6 mb-3">
            <label for="inputNombre" class="form-label">Nombre</label>
            <div class="input-group">
                <span class="input-group-text">ID </span>
                <asp:TextBox type="text" placeholder="Nombre" CssClass="form-control" ID="txtNombre" runat="server" />
                <asp:TextBox type="text" placeholder="Codigo" CssClass="form-control" ID="txtCodigo" runat="server" />
            </div>
        </div>

        <div class="col-6 mb-3">
            <label for="inputAddress2" class="form-label">Precio:</label>
            <div class="input-group">
                <span class="input-group-text">$</span>
                <asp:TextBox type="text" placeholder="Ingresar precio.." CssClass="form-control" ID="txtPrecio" runat="server" />
            </div>
        </div>
        <div class="col-6 mb-3">
            <label for="inputAddress" class="form-label">Descripcion:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox>
        </div>

        <div class="col-md-3 mb-3">
            <label for="inputStatee" class="form-label">State</label>
            <select id="inputStatee" class="form-select">
                <option selected>Choose...</option>
                <option>...</option>
            </select>
        </div>
        <div class="col-md-3 mb-3">
            <label for="inputState" class="form-label">State</label>
            <select id="inputState" class="form-select">
                <option selected>Choose...</option>
                <option>...</option>
            </select>
        </div>
        <div class="col-12 mb-3">
            <div class="form-check">
                <input class="form-check-input" type="checkbox" id="gridCheck">
                <label class="form-check-label" for="gridCheck">
                    Check me out
                </label>
            </div>
        </div>
        <div class="col-12 mb-3">
            <button type="submit" class="btn btn-primary">Sign in</button>
        </div>
    </form>










</asp:Content>
