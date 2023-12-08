<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="ArticleManager_Web.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="padding: 20px; margin-left: 0;" class="container">

        <h1 style="color: white">Carrito de compras</h1>
        <h4 style="color: white">A continuacion podras ver tus articulos agregados, traquilo, ya falta poco para que sean tuyos</h4>
        <asp:Repeater ID="rpRepetidor" runat="server">
            <ItemTemplate>
                <div class="card mb-3" style="max-width: 540px;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#Eval("URLImagen.URL")%>" class="img-fluid rounded-start" alt="...">
                        </div>
                        <div class="col-md-8">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("NombreArticulo") %></h5>
                                <h4 class="card-title">Total $<%# Convert.ToDecimal(Eval("Cantidad")) * Convert.ToDecimal(Eval("Precio")) %></h4>
                                <p class="card-text">Marca: <%#Eval("Marca")%></p>
                                <p class="card-text"><small class="text-body-secondary">Descripcion: <%#Eval("Descripcion")%></small></p>
                                <p>
                                    <h6 class="card-title">Total: <%#Eval("Cantidad")%></h6>
                                </p>
                                <asp:Button ID="btnEliminarCarrito" runat="server" CssClass="btn btn-danger" Text="Eliminar del carrito" CommandArgument='<%#Eval("IdArticulo")%>' CommandName="IdArticulo" OnClick="btnEliminarCarrito_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Button Text="Comprar" CssClass="btn btn-success" ID="btnComprar" runat="server" OnClick="btnComprar_Click" />
        <asp:Button Text="Volver" CssClass="btn btn-danger" ID="btnVolverCarrito" runat="server" OnClick="btnVolverCarrito_Click"/>
    </div>
</asp:Content>
