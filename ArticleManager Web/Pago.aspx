﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="ArticleManager_Web.Pago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table th {
            background-color: rebeccapurple !important;
            color: white !important;
        }

        .table tbody tr:nth-of-type(even) {
            background-color: white;
        }


        .table tbody tr:nth-of-type(odd) {
            background-color: #f8f9fa;
        }

        .buttoncolor {
            color: rebeccapurple;
            border: 2px solid;
            border-color: rebeccapurple;
            background-color: black;
        }

        .form-select:focus {
            border-color: rebeccapurple;
            box-shadow: 0 0 0 0.25rem rgba(138, 43, 226, 0.25);
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin-top: 50px;" class="container">
        <div style="text-align: center; font-size: 24px; color: white; margin-bottom: 20px; background-color: rebeccapurple; padding: 10px; border: 1px solid white; font-weight: bold;" class="table-title">
            Resumen de compra
        </div>
        <asp:GridView ID="dgvArticulosComprados" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
            <Columns>
                <asp:BoundField HeaderText="Codigo Articulo" DataField="CodigoArticulo" />
                <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />
                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            </Columns>
        </asp:GridView>
    </div>

    <div style="margin-top: 50px;" class="container">

        <h1 style="text-align: center; font-size: 40px; color: white; margin-bottom: 10px; background-color: rebeccapurple; border: 1px solid white; font-weight: bold;" class="precio">Total a abonar: $<%= PrecioTotal%></h1>
    </div>

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" />
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
    <div style="margin-top: 50px;" class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div style="border: none; border-radius: 10px; box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);" class="card">
                    <div style="background-color: rebeccapurple; color: white; border-radius: 10px 10px 0 0;" class="card-header text-center">
                        <h3>Gestioná tu pedido</h3>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="form-check">
                                    <asp:CheckBox ID="chkHayDireccion" runat="server" AutoPostBack="true" Enabled="true" Checked='<%# Direccion.Status %>' OnCheckedChanged="chkHayDireccion_CheckedChanged"></asp:CheckBox>
                                    <asp:Label Text="Usa tu direccion predeterminada" ID="lblHayDireccion" CssClass="form-check-label" runat="server" />
                                </div>

                                <div class="mb-3">
                                    <label for="ddlMetodoPago" style="font-weight: bold;" class="form-label">Método de Pago*</label>
                                    <asp:DropDownList ID="ddlMetodoPago" placeholder="Seleccione tipo de envio" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                                        <asp:ListItem Text="-- Selecciona una opción --" Value="" />
                                        <asp:ListItem Text="Efectivo" Value="1" />
                                        <asp:ListItem Text="Transferencia bancaria" Value="2" />
                                        <asp:ListItem Text="Mercado Pago" Value="3" />
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="ddlOpcionesEnvio" style="font-weight: bold;" class="form-label">Tipo de Entrega*</label>
                                    <asp:DropDownList ID="ddlOpcionesEnvio" placeholder="Seleccione tipo de envio" runat="server" CssClass="form-select" AutoPostBack="true" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlOpcionesEnvio_SelectedIndexChanged">
                                        <asp:ListItem Text="-- Selecciona una opción --" Value="" />
                                        <asp:ListItem Text="Entrega a domicilio" Value="1" />
                                        <asp:ListItem Text="Retiro en local" Value="2" />
                                    </asp:DropDownList>
                                </div>





                                <div class="mb-3">
                                    <label for="ddlOpcionesProvincias" style="font-weight: bold;" class="form-label">Provincia*</label>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="ddlOpcionesCiudades" style="font-weight: bold;" class="form-label">Ciudad*</label>
                                    <asp:DropDownList ID="ddlCiudad" placeholder="- Opciones -" runat="server" CssClass="form-select"></asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" style="font-weight: bold;" class="form-label">Calle*</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtCalle" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" style="font-weight: bold;" class="form-label">Numero*</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtNumero" onkeypress="return soloNumeros(event)" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" style="font-weight: bold;" class="form-label">Piso</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtPiso" onkeypress="return soloNumeros(event)" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" style="font-weight: bold;" class="form-label">Departamento</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtDepartamento" runat="server" />
                                </div>
                                <div class="form-check">

                                    <asp:CheckBox ID="chkDireccion" runat="server"></asp:CheckBox>
                                    <asp:Label Text="Guarda tu direccion" Style="font-weight: bold;" ID="lblDireccion" CssClass="form-check-label" runat="server" />
                                </div>
                                <br>
                                <br>
                                <asp:Button Text="Confirmar pedido" CssClass="btn btn-success" ID="btnPagar" runat="server" OnClick="btnPagar_Click" />
                                <asp:Button Text="Volver" CssClass="btn btn-danger" ID="btnVolverPago" runat="server" OnClick="btnVolverPago_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>








</asp:Content>
