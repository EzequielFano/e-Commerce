<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="ArticleManager_Web.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .buttoncolor {
            color: rebeccapurple;
            border: 2px solid;
            border-color: rebeccapurple;
            background-color: black;
            font-size: 18px;
            padding: 10px 20px; 
            margin-left: 20px;
        }
    </style>
    <div style="background-color: black" class="container mt-5">
        <div style="background-color: black" class="card">
            <div class="card-body text-center">
                <h1 class="card-title text-danger">¡Ups! Hubo un problema</h1>
                <asp:Label Text="text" ID="lblMensajeError" runat="server" ForeColor="White" Font-Size="XXLarge" />
                <a href="<%=Ruta %>" class="btn btn-outline-success buttoncolor">Volver</a>
            </div>
        </div>
    </div>
</asp:Content>


