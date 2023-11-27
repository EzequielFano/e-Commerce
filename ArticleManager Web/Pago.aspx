<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ArticleManager_Web.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Detalles de la compra: </h2>
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
    <br />

    <h4 style="">El total a pagar es de $<%= PrecioTotal%></h4>

    <br />


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
    <script>
        function soloNumeros(event) {
            const charCode = (event.which) ? event.which : event.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                event.preventDefault();
                return false;
            }

            return true;
        }
    </script>

    <asp:ScriptManager runat="server" ID="ScriptManager" />
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        <h3>Gestioná tu pedido</h3>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="mb-3">
                                    <label for="ddlMetodoPago" class="form-label">Método de Pago</label>
                                    <asp:DropDownList ID="ddlMetodoPago" placeholder="Seleccione tipo de envio" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- Selecciona una opción --" Value="" />
                                        <asp:ListItem Text="Efectivo" Value="1" />
                                        <asp:ListItem Text="Transferencia bancaria" Value="2" />
                                        <asp:ListItem Text="Mercado Pago" Value="3" />
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
                                    <label for="ddlOpcionesProvincias" class="form-label">Provincia</label>
                                    <asp:DropDownList ID="ddlProvincia" placeholder="- Opciones -" runat="server" CssClass="form-select" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="ddlOpcionesCiudades" class="form-label">Ciudad</label>
                                    <asp:DropDownList ID="ddlCiudad" placeholder="- Opciones -" runat="server" CssClass="form-select"></asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Calle</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtCalle" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Numero</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtNumero" onkeypress="return soloNumeros(event)" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Piso</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtPiso" onkeypress="return soloNumeros(event)" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Departamento</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtDepartamento" runat="server" />
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Bootstrap JS (opcional, si necesitas funcionalidades específicas de Bootstrap) -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>




    <asp:Button Text="Ir a pagar" CssClass="btn btn-success" ID="btnPagar" runat="server" OnClick="btnPagar_Click" />
    <a href="Carrito.aspx">Volver</a>
</asp:Content>
