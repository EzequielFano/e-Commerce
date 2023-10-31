<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="ArticleManager_Web.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color:white">Detalle del articulo</h1>

        <asp:Repeater ID="rpRepetidorImg" runat="server">
            <ItemTemplate>
                <img src="<%#Eval("URL") %>" class="img-thumbnail" alt="...">
            </ItemTemplate>
        </asp:Repeater>
    <%//Detalles %>
    <asp:Repeater ID="rpDetalles" runat="server">
        <ItemTemplate>
            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title"><%#Eval("NombreArticulo") %></h5>
                    <h4>$ <%#Eval("Precio") %></h4>
                    <p class="card-text">Descripcion: <%#Eval("Descripcion")%></p>
                    <p class="card-text">
                        <medium class="text-body-secondary">Marca: <%#Eval("Marca")%></medium>
                    </p>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
