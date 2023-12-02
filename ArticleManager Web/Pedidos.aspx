<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="ArticleManager_Web.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Pedidos activos</h2>

    <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" DataKeyNames="IdTransaccion" CssClass="table table-dark table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID Transaccion" DataField="IdTransaccion" />
            <asp:BoundField HeaderText="ID Usuario" DataField="User.IdUsuario" />
            <asp:BoundField HeaderText="Fecha de compra" DataField="FechaTransaccion" />
            <asp:BoundField HeaderText="Direccion de envio" DataField="Direccion.IdDireccion" />
            <asp:BoundField HeaderText="Importe total" DataField="Importe" />
            <asp:BoundField HeaderText="Numero de seguimiento" DataField="NroSeguimiento" />
            <asp:BoundField HeaderText="Tipo de pago" DataField="TipoPago" />
            <asp:TemplateField HeaderText="Estado del envio">
                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-dark" SelectText="Ver detalles" HeaderText="Accion" />
        </Columns>
    </asp:GridView>







    </asp:Content>
