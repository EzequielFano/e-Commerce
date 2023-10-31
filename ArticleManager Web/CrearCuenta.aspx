<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="CrearCuenta.aspx.cs" Inherits="ArticleManager_Web.CrearCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp
    &nbsp
   <div class="row g-3 align-items-center">
  <div class="col-auto">
    <label for="txtNombre" class="col-form-label">Nombre: </label>
  </div>
  <div class="col-auto">
    <input type="text" id="txtNombre" class="form-control">
  </div>
</div>
    &nbsp
    &nbsp
   <div class="row g-3 align-items-center">
  <div class="col-auto">
    <label for="txtApellido" class="col-form-label">Apellido: </label>
  </div>
  <div class="col-auto">
    <input type="text" id="txtApellido" class="form-control">
  </div>
</div>
        &nbsp
    &nbsp
   <div class="row g-3 align-items-center">
  <div class="col-auto">
    <label for="txtEmail" class="col-form-label">Email:    </label>
  </div>
  <div class="col-auto">
    <input type="text" id="txtEmail" class="form-control" aria-describedby="emailHelp">
     <div id="emailHelp" class="form-text">Nunca compartiremos tu informacion con nadie.</div>
  </div>
</div>
</asp:Content>
