<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Articulos.aspx.cs" Inherits="ArticleManager_Web.Articulos1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="container mt-4">
            <div class="d-flex justify-content-end">
                <form class="d-flex align-self-auto" role="search">
                    <asp:TextBox ID="txtBuscador" CssClass="form-control" placeholder="Filtro" runat="server"></asp:TextBox>
                    &nbsp
                                        <asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-outline-success" OnClick="btnBuscar_Click" Text="Buscar" />
                    &nbsp
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-outline-danger" OnClick="btnReset_Click" Text="Resetear" />
                </form>
            </div>
        </div>
        <div class="container">
            <div class="d-flex  justify-content-center mt-2">
                <h1 style="color: white">Los mejores precios, al alcance de un click</h1>
            </div>
            <%if (!session)
                {%>
            <div class="d-flex  justify-content-center mt-2">
                <h3 style="color: forestgreen">No olvides loguearte para realizar tu compra --> </h3>
                &nbsp
            <asp:Button BorderColor="DarkGray" Text="Loguate aqui" ID="btnLogueate" CssClass="btn btn-success" runat="server" OnClick="btnLogueate_Click" />
            </div>
            <%} %>
        </div>
        <br>
        <br />


        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="rpRepetidor" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card text-bg-secondary mb-3" style="max-width: 18rem;">
                            <img src="<%#Eval("URLImagen.URL")%>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("NombreArticulo") %></h5>
                                <h4>$ <%#Eval("Precio") %></h4>
                                <p class="card-text"><%#Eval("Descripcion")%></p>
                                <a href="Detalles.aspx?id=<%#Eval("IdArticulo")%>">Ver Detalles</a>
                                <%if (session)
                                    {%>
                                <asp:Button ID="btnCarrito" runat="server" CssClass="btn btn-success" Text="Agregar al carrito" CommandArgument='<%#Eval("IdArticulo")%>' CommandName="IdArticulo" OnClick="btnCarrito_Click" />
                                <%} %>
                            </div>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>
</asp:Content>
