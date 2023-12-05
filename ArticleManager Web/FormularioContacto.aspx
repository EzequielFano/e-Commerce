<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="FormularioContacto.aspx.cs" Inherits="ArticleManager_Web.FormularioContacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
        <style>
           

            .containerrr {
                max-width: 600px;
                margin: 50px auto;
                padding: 20px;
                background-color: white;                
                box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);               
            }

            label {
                display: block;
                margin-bottom: 8px;
            }

            input, textarea {
                width: 100%;
                padding: 10px;
                margin-bottom: 15px;
                border: 1px solid #ccc;
                border-radius: 4px;
                box-sizing: border-box;
            }

            button {
                background-color: rebeccapurple;
                color: white;
                padding: 12px 20px;
                border: none;
                border-radius: 4px;
                cursor: pointer;
            }

                button:hover {
                    background-color: #59377a;
                }
        </style>

        <div class="containerrr">
            <h2>Contacto</h2>

            <label for="nombre">Nombre:</label>
            <input type="text" id="nombre" name="nombre" required>

            <label for="email">Correo Electrónico:</label>
            <input type="email" id="email" name="email" required>

            <label for="consulta">Consulta:</label>
            <textarea id="consulta" name="consulta" rows="4" required></textarea>

            <button type="submit">Enviar</button>

        </div>
</asp:Content>
