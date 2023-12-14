<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DireccionEditable.aspx.cs" Inherits="ArticleManager_Web.DireccionEditable" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/css/bootstrap.min.css" />

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
            box-shadow: 0 0 0 0.25rem rgba(138, 43, 226, 0.25);
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
                        <h3>TU DIRECCION</h3>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="mb-3">
                                    <label for="ddlOpcionesProvincias" class="form-label">Provincia*</label>
                                    <asp:DropDownList ID="ddlProvincia" runat="server" CssClass="form-select" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged1">
                                    </asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="ddlOpcionesCiudades" class="form-label">Ciudad*</label>
                                    <asp:DropDownList ID="ddlCiudad" placeholder="- Opciones -" runat="server" CssClass="form-select"></asp:DropDownList>
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Calle*</label>
                                    <asp:TextBox CssClass="form-control textboxcrear" ID="txtCalle" runat="server" />
                                </div>
                                <div class="mb-3">
                                    <label for="txtDireccion" class="form-label">Numero*</label>
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
                          
                                <br>
                                <br>
                                <div>
                                    <asp:Button Text="Confirmar edicion" CssClass="btn btn-warning" ID="btnConfirmarEdicion" runat="server" OnClick="btnConfirmarEdicion_Click" />
                                    <asp:Button Text="Eliminar direccion" CssClass="btn btn-danger" ID="btnEliminarDireccion" runat="server" OnClick="btnEliminarDireccion_Click" />
                                </div>
                                <br />
                                <asp:Button Text="Volver" CssClass="btn btn-light buttoncolor" ID="btnVolverPerfil" runat="server" OnClick="btnVolverPerfil_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
