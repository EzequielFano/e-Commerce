<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="ArticleManager_Web.CrearCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!DOCTYPE html>

    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css">
    \

    <style>
        .textboxcrear {
            border-radius: 50px;
            height: 39px;
            justify-content: center;
            align-items: center;
        }

        .form-label {
            font-weight: bold;
            color: rebeccapurple;
            border-radius: 50px;
            height: 39px;
        }

        .buttoncolor {
            font-weight: bold;
            color: rebeccapurple;
            border-color: rebeccapurple;
        }
    </style>


    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header text-center">
                        <h3 style="border-radius: 50px; height: 39px; color: rebeccapurple">Registro de Usuario</h3>
                    </div>
                    <div class="card-body">


                        <div class="mb-3">
                            <label class="form-label">Nombre:</label>
                            <asp:TextBox CssClass="form-control textboxcrear" ID="txtNombre" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Apellido:</label>
                            <asp:TextBox CssClass="form-control textboxcrear" ID="txtApellido" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Email:</label>
                            <asp:TextBox CssClass="form-control textboxcrear" ID="txtEmail" runat="server" />
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Contraseña:</label>
                            <asp:TextBox type="password" CssClass="form-control textboxcrear" ID="txtContra" runat="server" />
                        </div>
                        <div class="row">
                            <div class="col -5">
                            </div>
                        </div>

                        <div class="text-center">

                            <asp:Button ID="btnCrearCuenta" Text="Crear Cuenta" CssClass="btn btn-outline-success buttoncolor" runat="server" OnClick="btnCrearCuenta_Click" />
                            <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-outline-success buttoncolor" OnClick="btnVolver_Click" runat="server" />
                        </div>

                    </div>
                    <br>
                </div>

            </div>
        </div>
    </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>


</asp:Content>
