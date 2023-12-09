<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioContacto.aspx.cs" Inherits="ArticleManager_Web.FormularioContacto" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .containerrr {
            max-width: 600px;
            margin: 50px auto 0;
            padding: 20px;
            background-color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        label {
            display: block;
            margin-bottom: 8px;
        }

        input,
        textarea {
            width: 100%;
            padding: 10px;
            margin-bottom: 15px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .buttoncolor {
            color: rebeccapurple;
            border: 2px solid rebeccapurple;
            background-color: black;
        }
    </style>

    <div class="containerrr">
        <h2>Contacto</h2>

        <asp:Label ID="lblNombreConsulta" runat="server" AssociatedControlID="txtNombreConsulta">Nombre:</asp:Label>
        <asp:TextBox ID="txtNombreConsulta" runat="server" CssClass="form-control" Required="true"></asp:TextBox>

        <asp:Label ID="lblEmailConsulta" runat="server" AssociatedControlID="txtEmailConsulta">Correo Electrónico:</asp:Label>
        <asp:TextBox ID="txtEmailConsulta" runat="server" CssClass="form-control" TextMode="Email" Required="true"></asp:TextBox>

        <asp:Label ID="lblConsulta" runat="server" AssociatedControlID="txtConsulta">Consulta:</asp:Label>
        <asp:TextBox ID="txtConsulta" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Required="true"></asp:TextBox>

        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-outline-success buttoncolor" OnClick="btnEnviar_Click" />

    </div>
    <br />
    <br />
    <br />
</asp:Content>
