<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ArticleManager_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="d-flex justify-content-center">
         <h2 style="color:white"> Te damos la bieniveda a nuestro primer carrito</h2>
        </div>
    </div>
     <div class="container">
        <div class="d-flex justify-content-center">
            <h2  style="color:white"> te invitamos a nuestro inicio para conocer el catalogo</h2>
        </div>
    </div>
     <div class="container">
        <div class="d-flex justify-content-center">
            <asp:Button Text="Comenzar a navegar" ID="btnComenzar" runat="server" CssClass="btn btn-success" Font-Size="XX-Large" OnClick="btnComenzar_Click" />
     </div>
 </div>
</asp:Content>
