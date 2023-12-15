<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="DetallesTransacciones.aspx.cs" Inherits="ArticleManager_Web.DetallesTransacciones" %>

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
                    <h5 class="card-title mb-2"><b>Direccion</b></h5>
                    <%if (OpcionEnvio != 2)
                        { %>
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
                    <br /> 
                      <p class="card-text mb-1"<b>EL CLIENTE RETIRA POR EL LOCAL.</b></p>
                    
                    
                    <%}%>
                </div>
                <div class="card-footer text-body-secondary">
                </div>
            </div>
        </div>

        <div class="col-md-5 mb-3">
            <div class="card text-center">
                <div class="table-title mb-2">
                    Informacion del Usuario
                </div>
                <div class="card-body">
                    <h5 class="card-text mb-2"><b>Usuario ID: </b><%=Usuario.IdUsuario %></h5>
                    <p class="card-text mb-1"><b>Nombre: </b><%=Usuario.Nombre%></p>
                    <p class="card-text mb-1"><b>Apellido: </b><%=Usuario.Apellido %></p>
                    <p class="card-text mb-0"><b>Email: </b><%=Usuario.Email%></p>
                </div>
                <div class="card-footer text-body-secondary">
                </div>
            </div>
        </div>
        <asp:Button ID="btnEnviarMail" Text="ENVIAR MAIL AL USUARIO" CssClass="btn btn-custom" OnClick="btnEnviarMail_Click" runat="server" style="margin-right: 10px;" />
        <%if (estado.ToString() != "FINALIZADO")
            { %>
            <button type="button" class="btn btn-custom" data-bs-toggle="modal" data-bs-target="#exampleModal">
            CAMBIAR EL ESTADO DE ESTA TRANSACCION
            </button>
       <%} %>
    </div>
  
        <br />
       
    <a href="<%=Ruta %>" class="btn btn-outline-light" style="display: block; margin: 0 auto; text-align: center; color: rebeccapurple; max-width: 10%">Volver</a>

    <br />
    <br />
    <style>
        .btn-custom {
            background-color: #8a2be2;
            color: #ffffff;
            transition: background-color 0.3s ease;
            max-width: 40%
        }

            .btn-custom:hover {
                background-color: #a74dd1;
            }
    </style>





  <!-- Modal -->
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header card-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Modal title</h1>
                <button type="button" class="btn-close"  data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body card-body">
                ¿ESTÁS SEGURO QUE QUERES CAMBIAR EL ESTADO DE LA TRANSACCION?
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-close-white" data-bs-dismiss="modal">Cerrar</button>
                <asp:Button ID="btnCambiarEstado" CssClass="btn btn-custom" OnClick="btnCambiarEstado_Click" runat="server" style="margin-left: 10px;" />
            </div>
        </div>
    </div>
</div>


</asp:Content>
