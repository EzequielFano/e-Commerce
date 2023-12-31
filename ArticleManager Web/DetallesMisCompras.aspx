﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetallesMisCompras.aspx.cs" Inherits="ArticleManager_Web.DetallesMisCompras" %>

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

        .card {
            max-width: 600px;
            margin: auto;
        }

        .card-body {
            text-align: left;
        }

        .card-header {
            background-color: rebeccapurple !important;
            color: #f8f9fa;
        }

        .buttoncolor {
            color: rebeccapurple;
            border: 2px solid;
            border-color: rebeccapurple;
            background-color: black;
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

    <div class="row justify-content-center">
        <div class="col-md-5 mb-3">
            <div class="card text-center">
                <div class="table-title mb-2">
                    Informacion de envio
                </div>
                <div class="card-body">
                    <%if (Direccion.Pais != null || Direccion.Provincia != null)
                        { %>
                    <h5 class="card-title mb-2"><b>Direccion</b></h5>
                    <p class="card-text mb-1"><b>Pais:</b> <%=Direccion.Pais%></p>
                    <p class="card-text mb-1"><b>Provincia: </b><%=Direccion.Provincia %></p>
                    <p class="card-text mb-1"><b>Ciudad: </b><%=Direccion.Ciudad%></p>
                    <p class="card-text mb-1"><b>Calle: </b><%=Direccion.Calle%></p>
                    <p class="card-text mb-1"><b>Numero: </b><%=Direccion.Numero%></p>
                    <p class="card-text mb-1"><b>Piso: </b><%=Direccion.Piso%></p>
                    <p class="card-text mb-0"><b>Departamento: </b><%=Direccion.Departamento%></p>
                    <%}
                        else
                        { %>                    
                    <p class="card-text mb-1"><b>RETIRO EN EL LOCAL.</b></p>


                    <%}%>
                </div>
                <div class="card-footer text-body-secondary">
                    <asp:Button ID="btnVolverDetallesMisCompras" CssClass="btn btn-outline-success buttoncolor" OnClick="btnVolverDetallesMisCompras_Click" Text="Volver" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
