<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="ArticleManager_Web.Articulos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .buttoncolor1, .buttoncolor1:hover {
            color: rebeccapurple;
            border: 2px solid rebeccapurple;
            background-color: black;
            padding: 10px 20px;
            text-decoration: none;
            border-radius: 5px;
            display: inline-block;
            transition: background-color 0.3s ease;
        }
    </style>

    <div class="container mt-4">

        <div class="container">
            <div class="d-flex  justify-content-center mt-2">
                <h1 style="color: white; font-size: 36px; text-align: center; font-weight: bold; text-shadow: 2px 2px 4px rgba(0, 0, 0, 0.5);">Los mejores precios, al alcance de un click</h1>

            </div>
            <%if (!session)
                {%>
            <div class="d-flex  justify-content-center mt-2">
                <h3 style="color: forestgreen; font-size: 24px; margin-top: 20px; margin-bottom: 10px; font-weight: bold; text-align: center;">No olvides loguearte para realizar tu compra -->  </h3>
                &nbsp
            <asp:Button Text="Loguate aqui" ID="btnLogueate" CssClass="btn btn-outline-success buttoncolor" runat="server" OnClick="btnLogueate_Click" />
            </div>
            <%} %>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4" style="margin-top: 20px; margin-left: 120px;">
        <asp:Repeater ID="rpRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card text-bg-secondary mb-3" style="width: 25rem; border: 6px ridge; border-color: rebeccapurple">
                        <img src="<%#Eval("URLImagen.URL")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("NombreArticulo") %></h5>
                            <h4>$ <%#Eval("Precio") %></h4>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="Detalles.aspx?id=<%#Eval("IdArticulo")%>" class="buttoncolor1">Ver Detalles</a>



                            <%if (session)
                                {%>
                            <br>
                            <br>
                            <br>
                            <p>
                                <label>Cantidad:</label>
                                <asp:TextBox ID="txtCantidad" runat="server" onkeypress="return soloNumeros(event)" Text="1" />
                                <br>
                                <br>
                                <asp:Button ID="btnCarrito" runat="server" CssClass="btn btn-success" Text="Agregar al carrito" CommandArgument='<%#Eval("IdArticulo")%>' CommandName="IdArticulo" OnClick="btnCarrito_Click" />
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
                                <label>(<%#Eval("cantidad")%> disponibles)</label>
                            </p>
                            <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>


</asp:Content>
