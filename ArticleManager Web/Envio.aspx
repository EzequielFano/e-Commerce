<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Envio.aspx.cs" Inherits="ArticleManager_Web.Envio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" />
    <!-- Estilo personalizado -->
    <style>
        body {
            background-color: rebeccapurple;
        }

        .container {
            margin-top: 50px;
        }

        .card {
            border: none;
            border-radius: 10px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
        }

        .card-header {
            background-color: rebeccapurple;
            color: white;
            border-radius: 10px 10px 0 0;
        }

        .form-label {
            font-weight: bold;
        }

        .buttoncolor {
            color: rebeccapurple;
            border: 2px solid;
            border-color: rebeccapurple;
            background-color: black;
        }

        .form-select:focus {
            border-color: rebeccapurple;
            box-shadow: 0 0 0 0.25rem rgba(138, 43, 226, 0.25); /* Cambia este color también */
        }
    </style>


    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Gestioná tu pedido</h3>
                    </div>
                    <div class="card-body">
                        <div class="mb-3">
                            <label for="ddlMetodoPago" class="form-label">Método de Pago</label>
                            <asp:DropDownList ID="ddlMetodoPago" placeholder="Seleccione tipo de envio" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- Selecciona una opción --" Value="" />
                                <asp:ListItem Text="Transferencia bancaria" Value="1" />
                                <asp:ListItem Text="Mercado Pago" Value="2" />
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="ddlOpcionesEnvio" class="form-label">Tipo de Entrega</label>
                            <asp:DropDownList ID="ddlOpcionesEnvio" placeholder="Seleccione tipo de envio" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                <asp:ListItem Text="-- Selecciona una opción --" Value="" />
                                <asp:ListItem Text="Entrega a domicilio" Value="1" />
                                <asp:ListItem Text="Retiro en local" Value="2" />
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <label for="txtDireccion" class="form-label">Dirección de Envío</label>
                            <asp:TextBox CssClass="form-control textboxcrear" ID="txtDireccion" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS (opcional, si necesitas funcionalidades específicas de Bootstrap) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
