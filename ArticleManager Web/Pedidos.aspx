<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="ArticleManager_Web.Pedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .containerPedidos {
            margin-top: 50px;
            margin-left: 50px;
            margin-right: 50px;
            margin-bottom: 0px;

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

        .table tbody tr:nth-of-type(even) {
            background-color: white;
        }

        .table th {
            background-color: rebeccapurple !important;
            color: white !important;
        }

        .table tbody tr:nth-of-type(odd) {
            background-color: #f8f9fa;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="containerPedidos">
        <div class="table-title">
            Pedidos Activos
        </div>
        <asp:GridView ID="dgvPedidos" runat="server" OnSelectedIndexChanged="dgvPedidos_SelectedIndexChanged" DataKeyNames="IdTransaccion" AutoGenerateColumns="False" CssClass="table table-striped">
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
    </div>
</asp:Content>
