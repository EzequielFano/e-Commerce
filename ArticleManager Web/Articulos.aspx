<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="ArticleManager_Web.Articulos1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .buttoncolor{
            color:rebeccapurple;
            border:2px solid;
            border-color:rebeccapurple;
            background-color:black;
        }
    </style>

    <div class="container mt-4">
       
        <div class="container">
            <div class="d-flex  justify-content-center mt-2">
                <h1 style="color: white">Los mejores precios, al alcance de un click</h1>
            </div>
            <%if (!session)
                {%>
            <div class="d-flex  justify-content-center mt-2">
                <h3 style="color: forestgreen">No olvides loguearte para realizar tu compra --> </h3>
                &nbsp
            <asp:Button Text="Loguate aqui" ID="btnLogueate" CssClass="btn btn-outline-success buttoncolor" runat="server" OnClick="btnLogueate_Click" />
            </div>
            <%} %>
        </div>
    </div>

    <div class="row row-cols-1 row-cols-md-3 g-4" style="margin-top:20px;margin-left:120px;">
        <asp:Repeater ID="rpRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card text-bg-secondary mb-3" style="max-width: 18rem;border:6px ridge;border-color:rebeccapurple">
                        <img src="<%#Eval("URLImagen.URL")%>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("NombreArticulo") %></h5>
                            <h4>$ <%#Eval("Precio") %></h4>
                            <p class="card-text"><%#Eval("Descripcion")%></p>
                            <a href="Detalles.aspx?id=<%#Eval("IdArticulo")%>">Ver Detalles</a>


                            <%if (session)
                                {%>
                            <p>
                                <label>Cantidad:</label>
                                <asp:TextBox ID="txtCantidad" runat="server" onkeypress="return soloNumeros(event)" Text="1"/>
                               

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
                                <label>(<%#Eval("cantidad")%>disponibles)</label>
                            </p>
                            &nbsp &nbsp &nbsp
                            <%} %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
