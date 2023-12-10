<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="PedidosRecibidos.aspx.cs" Inherits="ArticleManager_Web.PedidosRecibidos" %>

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

        .oculto {
            display: none;
        }

        .nav-tabs {
            background-color: black;
        }

        .nav-link.grilla {
            color: #8a2be2 !important;
        }

            .nav-link.active {
                background-color: #8a2be2 !important;
                color: #fff !important;
            }

        #myTabs {
            display: flex;
            justify-content: center;
            box-sizing: border-box;
            max-width: 30%;
            margin: 0 auto;
        }

        .nav-link {
            padding: 8px 12px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <ul class="nav nav-tabs" id="myTabs">
        <li class="nav-item">
            <a class="nav-link grilla" aria-current="page" href="Pedidos.aspx" onclick="toggleActive(0)">Iniciados</a>
        </li>
        <li class="nav-item">
            <a class="nav-link grilla" href="PedidosEnviados.aspx" onclick="toggleActive(1)">En proceso</a>
        </li>
        <li class="nav-item">
            <a class="nav-link grilla" href="PedidosPagados.aspx" onclick="toggleActive(1)">Pagados</a>
        </li>
        <li class="nav-item">
            <a class="nav-link active" href="PedidosRecibidos.aspx" onclick="toggleActive(3)">Finalizados</a>
        </li>
    </ul>
    <div class="containerPedidos">
        <div class="table-title">
            PEDIDOS FINALIZADOS
        </div>
        <asp:GridView ID="dgvPedidosRecibidos" runat="server" OnSelectedIndexChanged="dgvPedidosRecibidos_SelectedIndexChanged" DataKeyNames="IdTransaccion" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField HeaderText="ID Transaccion" DataField="IdTransaccion" />
                <asp:BoundField HeaderText="ID Usuario" DataField="User.IdUsuario" />
                <asp:BoundField HeaderText="Fecha de compra" DataField="FechaTransaccion" />
                <asp:BoundField HeaderText="Metodo de envio" DataField="Direccion.IdDireccion" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
                <asp:BoundField HeaderText="Importe total" DataField="Importe" />
                <asp:BoundField HeaderText="Numero de seguimiento" DataField="NroSeguimiento" />
                <asp:BoundField HeaderText="Tipo de pago" DataField="TipoPago" />
                <asp:BoundField HeaderText="Estado del pedido" DataField="Estado" />
                <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-dark" SelectText="Ver detalles" HeaderText="Accion" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
