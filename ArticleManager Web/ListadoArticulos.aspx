<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ListadoArticulos.aspx.cs" Inherits="ArticleManager_Web.ListadoArticulos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .oculto {
            display: none;
        }

        .largeCheckbox {
            width: 20px;
            height: 20px;
        }

        .containerListado {
            margin-top: 50px;
            margin-left: 50px;
            margin-right: 50px;
            margin-bottom: 0px;
        }

        .table-title {
            text-align: center;
            font-size: 24px;
            color: white;
            margin-bottom: 20px;
            background-color: rebeccapurple;
            padding: 10px;
            border: 1px solid white;
            font-weight: bold;
        }

        .table tbody tr:nth-of-type(even) {
            background-color: white;
        }

        .table th {
            background-color: rebeccapurple !important;
            color: white !important;
        }

        .table tbody tr:nth-of-type(odd) {
            background-color: #f8f9fa;
        }
    </style>
    <div class="containerListado">
        <div class="table-title">
            Listado completo de articulos
        </div>


    <asp:GridView ID="dgvArticulos" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" DataKeyNames="IdArticulo" CssClass="table table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="IdArticulo" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />
            <asp:BoundField HeaderText="Codigo Articulo" DataField="CodigoArticulo" />
            <asp:BoundField HeaderText="Nombre" DataField="NombreArticulo" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Precio unitario" DataField="Precio" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:CheckBox ID="chkStatus" runat="server" OnCheckedChanged="chkStatus_CheckedChanged" Font-Names="IdArticulo" AutoPostBack="true" Checked='<%# Convert.ToBoolean(Eval("Status")) %>' Enabled="true" CssClass="largeCheckbox" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowSelectButton="true" ControlStyle-CssClass="btn btn-dark" SelectText="Editar" HeaderText="Accion" />
        </Columns>
    </asp:GridView>


    </div>
</asp:Content>
