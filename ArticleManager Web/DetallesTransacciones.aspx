<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetallesTransacciones.aspx.cs" Inherits="ArticleManager_Web.DetallesTransacciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .container {
            margin-top: 50px;
        }

        .table-title {
            text-align: center;
            font-size: 24px;
            color: white;
            margin-bottom: 20px;
            background-color: rebeccapurple;
            padding: 10px;
            border: 1px solid white;
            font-weight: bold;
        }


        .table th {
            background-color: rebeccapurple !important;
            color: white !important;
        }

        .precio {
            text-align: center;
            font-size: 40px;
            color: white;
            margin-bottom: 10px;
            background-color: rebeccapurple;
            border: 1px solid white;
            font-weight: bold;
        }


        .table tbody tr:nth-of-type(even) {
            background-color: white;
        }


        .table tbody tr:nth-of-type(odd) {
            background-color: #f8f9fa;
        }
    </style>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>

    <div class="container">
        <div class="table-title">
            Resumen de compra
        </div>

        <asp:GridView ID="dgvArticulosComprados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField HeaderText="Codigo Articulo" DataField="Articulo.CodigoArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="Articulo.NombreArticulo" />
                <asp:BoundField HeaderText="Categoria" DataField="Articulo.Categoria.Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Articulo.Marca.Descripcion" />
                <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            </Columns>
        </asp:GridView>
    </div>



</asp:Content>
