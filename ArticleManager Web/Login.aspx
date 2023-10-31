<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArticleManager_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%if (!session)
        {%>
    <div class="container">
        <div class="d-flex justify-content-center mt-4" >
            <h3 style="color:white">Ingrese sus datos para iniciar la sesion: </h3>
        </div>
    </div>
     <     <div class="container">
                <div class="mb-3">
                <label for="exampleInputEmail1" style="color:white" class="form-label">Usuario</label>
                <asp:TextBox cssClass="form-control" ID="txtUser" runat="server" />
                </div>
             
                <div class="mb-3">
                   <label for="exampleInputPassword1" style="color:white" class="form-label">Contraseña</label>
                    <asp:TextBox type="Password" CssClass="form-control" ID="txtPassword" runat="server" />
                </div>
                 <div class="mb-3">
                <asp:Button ID="btnIngresar" CssClass="btn btn-success" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                </div>
           </div>
             

    <%}
        else
        { %>
     <div class="container">
    <div class="d-flex justify-content-center mt-4">       
        <asp:Label ID="lblUser" cssClass="align-content-center " BackColor="white" BorderColor="Black" Font-Size="XX-Large" runat="server"></asp:Label>
    </div>
</div>
     <div class="container">
        <div class="d-flex justify-content-center mt-4">
           <h3 style="color:white">Te logueaste exitosamente a nuestro carrito de compras</h3>
            
        </div>
    </div>
    <br />
     <div class="container">
    <div class="d-flex justify-content-lg-evenly">
    <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-success" Text="Cerrar sesion" OnClick="btnCerrarSesion_Click" />
    <asp:Button ID="btnVolver" runat="server" Text="Comenzar a comprar" CssClass="btn btn-success" OnClick="btnVolver_Click"  />       
    </div>
</div>

    <%}%>
</asp:Content>
