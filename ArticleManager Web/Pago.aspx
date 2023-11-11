tatu<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ArticleManager_Web.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Aca vamos a configurar la parte del pago</h2>
    <asp:GridView ID="dgvArticulosComprados" runat="server" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Codigo Articulo" DataField="CodigoArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
        </Columns>
    </asp:GridView>
    <h4>El total a pagar es de $<%= PrecioTotal%></h4>

    <asp:Repeater id="rpRepeater" runat="server">
        <ItemTemplate>
            <div class="form-check">
                <input class="form-check-input" type="radio" name="exampleRadios" id="exampleRadios1" value="option1" checked>
                <label class="form-check-label" for="exampleRadios1">
                    Default radio
                </label>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:Button Text="Ir a pagar" CssClass="btn btn-success" ID="btnPagar" runat="server" OnClick="btnPagar_Click" />
    <a href="Carrito.aspx">Volver</a>
</asp:Content>
