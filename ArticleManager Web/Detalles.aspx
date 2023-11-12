<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Detalles.aspx.cs" Inherits="ArticleManager_Web.Detalles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="color: white">Detalle del articulo</h1>
    <style>
        /* Establece un tamaño fijo para el carrusel */
        #carouselExample {
            width: 300px; /* Ancho deseado del carrusel */
            height: 300px; /* Altura deseada del carrusel */
        }

        /* Establece un tamaño máximo para las imágenes en el carrusel */
        .carousel-img {
           max-width: 100%;  /*Ancho máximo al 100% del carrusel*/
           max-height: 100%; /*Altura máxima al 100% del carrusel*/     
            
        }
        .fa-star{
            color:rebeccapurple;
            border-inline-color:black;
            
        }
       #TituloArticulo{
           color:#555;
       }
       .new-arrival{
           background:green;
           width:50px;
           color:#fff;
           font-size:12px;
           font-weight:bold;           
       }
       .price{
           color:rebeccapurple;
           font-size:26px;
           font-weight:bold;
           padding-top:20px;
       }
       #lblcantidad{
           border:1px solid #ccc;
           font-weight:bold;
           height: 33px;
           text-align:center;
           width: 30px;
       }
       
       
    </style>
    <script defer src="https://use.fontawesome.com/releases/v5.15.4/js/all.js" integrity="sha384-rOA1PnstxnOBLzCLMcre8ybwbTmemjzdNlILg8O7z1lUkLXozs4DHonlDtnE7fpc" crossorigin="anonymous"></script>
    <div class="container">
        <div class="row">
            
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
            <div class="col -8">
                &nbsp
                &nbsp
                &nbsp
                 <asp:Repeater ID="rpDetalles" runat="server">
                     <ItemTemplate>
                         <div class="card mb-3">
                             <div class="card-body">
                                 <p class="new-arrival text-center">NEW</p>
                                 <h5 id="TituloArticulo" class="card-title"><%#Eval("NombreArticulo") %></h5>
                                 <i class="fa fa-star"></i>
                                 <i class="fa fa-star"></i>
                                 <i class="fa fa-star"></i>
                                 <i class="fa fa-star"></i>                                 
                                 <i class="fa fa-star"></i>
                                 <p class="price"><b>$ <%#Eval("Precio") %></b></p>
                                 <p class="card-text"><b>Descripcion: <%#Eval("Descripcion")%></b></p>
                                 <p class="card-text"><b>
                                     <medium class="text-body-secondary">Marca: <%#Eval("Marca")%></medium></b>
                                 </p>
                                 <label>Cantidad: </label>
                                 <input id="lblcantidad" type="text" value="1"/> &nbsp &nbsp &nbsp
                                 <asp:Button Text="Agregar al Carrito" runat="server" CssClass="btn btn-primary" BackColor="MediumPurple" BorderColor="MediumPurple"/>
                             </div>
                         </div>
                         
                     </ItemTemplate>
                 </asp:Repeater>
            </div>
          
        </div>
    </div>
    

   
</asp:Content>
