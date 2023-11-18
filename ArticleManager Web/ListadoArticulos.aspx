<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="ArticleManager_Web.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style> 
        .oculto{
            display: none;

        }
    </style>
    <h2>Listado completo de articulos</h2>
    <asp:GridView ID="dgvArticulos" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IdArticulo" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto"  />
            <asp:BoundField HeaderText="Codigo Articulo" DataField="CodigoArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:CommandField ShowSelectButton="true" SelectText="Seleccionar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>


</asp:Content>
