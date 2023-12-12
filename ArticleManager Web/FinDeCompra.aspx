<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FinDeCompra.aspx.cs" Inherits="ArticleManager_Web.Envio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        bodyFin {
            font-family: Arial, sans-serif;
            background-color: rebeccapurple;
            margin: 0;
            padding: 0;
            text-align: center;
        }

        .containerFin {
            max-width: 600px;
            margin: 50px auto;
            background-color: black;
            padding: 20px;
            border-radius: 8px;
            border: 2px rebeccapurple solid;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .h1Fin {
            color: rebeccapurple;
            font-weight: bold;
            text-align: center;
        }

        .pFin {
            color: #666;
            font-weight: bold;
            text-align: center;
        }

        .thank-you-message {
            font-size: 24px;
            color: #4CAF50;
            font-weight: bold;
        }

        }

        .back-to-home {
            margin-top: 20px;
            display: inline-block;
            padding: 10px 20px;
            text-decoration: none;
            background-color: #663399;
            color: #fff;
            border-radius: 4px;
            transition: background-color 0.3s;
        }

            .back-to-home:hover {
                background-color: #4a2a67;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="containerFin">
        <h1 class="h1Fin">¡Gracias por tu compra!</h1>
        <div class="thank-you-message">
            <p class="pFin">Tu pedido ha sido confirmado con éxito.</p>
            <p class="pFin">Estamos procesando tu solicitud y te enviaremos mas informacion por correo electrónico.</p>
        </div>
        <div style="text-align:center">
        <asp:Button CssClass="btn btn-outline-success buttoncolor" Text="Volver al inicio" runat="server" ID="btnVolverFindeCompra" OnClick="btnVolverFindeCompra_Click"/>
        </div>
    </div>
</asp:Content>
