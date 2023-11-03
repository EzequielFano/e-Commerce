<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="ArticleManager_Web.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: white">Detalle del articulo</h1>
    <style>
        /* Establece un tamaño fijo para el carrusel */
        #carouselExample {
            width: 300px; /* Ancho deseado del carrusel */
            height: 500px; /* Altura deseada del carrusel */
        }

        /* Establece un tamaño máximo para las imágenes en el carrusel */
        .carousel-img {
            max-width: 100%; /* Ancho máximo al 100% del carrusel */
            max-height: 100%; /* Altura máxima al 100% del carrusel */
            
        }
    </style>

    <div id="carouselExample" class="carousel slide">
        <div class="carousel-inner">
            <% for (int i = 0; i < ListaImagenes.Count(); i++)
                { %>
            <div class="carousel-item<% if (i == 0)
                { %> active<% } %>">
                <img src="<%= ListaImagenes[i].URL %>" class="d-block w-100 carousel-img" alt="Imagen <%= i + 1 %>">
            </div>
            <% } %>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>

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
