<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="ArticleManager_Web.MisCompras" %>

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
    <div class="containerPedidos">
        <div class="table-title">
            Mis compras
        </div>
        <div class="row">
            <asp:Repeater ID="rptMisCompras" runat="server" OnItemDataBound="rptMisCompras_ItemDataBound">
                <ItemTemplate>
                    <div class="col-md-4">
                        <div style="border:4px rebeccapurple solid" class="card mb-4">
                            <div class="card-header">
                                <span class="card-title">ID: <%# Eval("IdTransaccion") %></span>
                                <span class="card-date">Fecha de compra: <%# Eval("FechaTransaccion", "{0:dd/MM/yyyy}") %></span>
                            </div>
                            <div class="card-body">
                                <p>Metodo de envio: <%# Eval("Direccion.IdDireccion") %></p>
                                <p>Importe total: <%# Eval("Importe") %></p>
                                <p>Numero de seguimiento: <%# Eval("NroSeguimiento") %></p>
                                <p>Tipo de pago: <%# Eval("TipoPago") %></p>
                                <p>Estado del pedido: <%# Eval("Estado") %></p>
                                <div>
                                    <asp:Button Text="Ver Detalle" CssClass="btn btn-outline-success buttoncolor" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>






</asp:Content>
