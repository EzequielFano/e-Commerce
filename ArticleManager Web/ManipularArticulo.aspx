<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="ManipularArticulo.aspx.cs" Inherits="ArticleManager_Web.ManipularArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-label {
            color: rebeccapurple;
            font-weight: bold;
        }

        .custom-form {
            margin-top: 50px;
            margin-left: auto;
            margin-right: auto;
            max-width: 120%;
        }

        .carousel-column {
            max-width: 500px;
            margin: auto;
            margin-top: 50px;
        }
    </style>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function updateImageUrl() {
            var carousel = $('#carouselExample');

            // Añadir un evento de escucha para cuando la transición del carrusel se complete
            carousel.on('slid.bs.carousel', function () {
                // Obtener la URL de la imagen después de que se haya completado la transición
                var activeItem = carousel.find('.carousel-item.active img');
                var imageUrl = activeItem.attr('src');

                // Actualizar la URL actual
                $('#txtURLActual').val(imageUrl);
                $('#txtURLImagen').val(imageUrl);

                // Remover el evento después de completar la actualización
                carousel.off('slid.bs.carousel');
            });

            // Realizar la transición del carrusel
            carousel.carousel('next');
        }
    </script>


    <div style="display: flex; justify-content: space-between;" class="container">
        <div class="col-md-8 mb-3">
            <div class="custom-form">
                <div class="col-8 mb-3">
                    <label for="inputNombre" class="form-label">Nombre:</label>
                    <div class="input-group">
                        <span class="input-group-text">ID </span>
                        <asp:TextBox type="text" placeholder="Nombre" CssClass="form-control" ID="txtNombre" runat="server" />
                        <asp:TextBox type="text" placeholder="Codigo" CssClass="form-control" ID="txtCodigo" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3 mb-3">
                        <div class="form-group">
                            <label for="txtPrecio" class="form-label">Precio:</label>
                            <div class="input-group">
                                <span class="input-group-text">$</span>
                                <asp:TextBox type="text" placeholder="Ingresar precio..." CssClass="form-control" ID="txtPrecio" runat="server" />
                            </div>
                        </div>
                    </div>

                    <div class="col-3 mb-3">
                        <div class="form-group">
                            <label for="txtCantidad" class="form-label">Cantidad:</label>
                            <asp:TextBox type="text" placeholder="Ingresar cantidad..." CssClass="form-control" ID="txtCantidad" runat="server" />
                        </div>
                    </div>
                </div>

                <div class="col-8 mb-3">
                    <label for="inputAddress" class="form-label">Descripcion:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" Columns="50"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col-md-3 mb-3">
                        <div class="form-group">
                            <label for="ddlCategoria" class="form-label">Categoria:</label>
                            <asp:DropDownList ID="ddlCategoria" PlaceHolder="Seleccionar.." CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-3 mb-3">
                        <div class="form-group">
                            <label for="ddlMarca" class="form-label">Marca:</label>
                            <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>

                <div class="col-8 mb-3">
                    <label for="inputAddress2" class="form-label">Nueva imagen:</label>
                    <div class="input-group">
                        <span class="input-group-text">URL</span>
                        <asp:TextBox type="text" CssClass="form-control" ID="txtURLImagen" runat="server" ClientIDMode="Static" Style="width: 60%" />
                    </div>
                    <br />
                    <div>
                        <asp:Button Text="Insertar nueva imagen" CssClass="btn btn-outline-light" runat="server" ID="btnNuevaImagen" OnClick="btnNuevaImagen_Click" />
                    </div>
                </div>
                <br />
                <br />
                <br />
                <div class="col-12 mb-3">
                    <asp:Button CssClass="btn btn-success" ID="btnAccion" OnClick="btnAccion_Click" runat="server" />
                </div>

                <div>
                </div>
            </div>
        </div>


        <div class="col-md-6 mb-3 carousel-column" style="max-width: 500px; min-width: 450px;">
            <br />
            <br />
            <div id="carouselExample" class="carousel slide">
                <div class="carousel-inner">
                    <%if (Request.QueryString["id"] != null)
                        {  %>
                    <% for (int i = 0; i < ListaImagenes.Count(); i++)
                        { %>
                    <div class="carousel-item<% if (i == 0)
                        { %> active<% } %>">
                        <img src="<%= ListaImagenes[i].URL %>" class="d-block w-100 carousel-img" alt="Imagen <%=i + 1%>">
                    </div>
                    <% }
                        }
                        else
                        { %>
                    <div class="carousel-item active">
                        <img src="https://redthread.uoregon.edu/files/original/affd16fd5264cab9197da4cd1a996f820e601ee4.png" class="d-block w-100" alt="...">
                    </div>
                   
                    <%} %>
                </div>
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next" onclick="updateImageUrl()">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
            <br />
            <div class="col-10 mb-3">
                <label for="inputAddress2" class="form-label">Imagen actual:</label>
                <div class="input-group">
                    <span class="input-group-text">URL</span>
                    <asp:TextBox type="text" CssClass="form-control" ID="txtURLActual" runat="server" ClientIDMode="Static" Style="max-width: 1%" />
                </div>
            </div>
            <br />
        </div>
    </div>
    <% if (Request.QueryString["id"] != null)
        { %>
    <br />
    <a href="<%=Ruta %>" class="btn btn-outline-light" style="display: block; margin: 0 auto; text-align: center; color: violet; max-width: 30%">Volver</a>
    <br />
    <%} %>
    <br />
</asp:Content>
