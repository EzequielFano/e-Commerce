<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="ArticleManager_Web.AboutUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleCaptions" class="carousel slide">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></button>

        </div>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="https://media.licdn.com/dms/image/C4E03AQFn3aMcCNS1Iw/profile-displayphoto-shrink_800_800/0/1653661926728?e=2147483647&v=beta&t=5LgxrGBxw4xkARfaC4hb56sfgs6rizPMLidEkXt-U5E" class="d-block w-100" style="transform: scale(0.5);" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:white">Ezequiel Fano</h2>
                    <p style="color:white">
                        Mi nombre es Ezequiel Fano, trabajo para la empresa Kupner SAS en un proyecto
que intenta lograr la trazabilidad en la planta Fate SAICI, como Proyect Manager.

Actualmente cursando el tercer cuatrimestre de la Tecnicatura Universitaria en 
Programacion de la UTN.

Me gusta jugar paddle y pasar musica

Espero disfrutes la app!
                    </p>
                </div>
            </div>
            <div class="carousel-item">
                <img src="https://media.licdn.com/dms/image/C5603AQEUauxLPoShnw/profile-displayphoto-shrink_800_800/0/1628795779160?e=2147483647&v=beta&t=zerFjT2k39xMwb_uzY_ZWE7y_4_tDGPHUoABqnTfrR0 " class="d-block w-100" style="transform: scale(0.5);" alt="...">
                <div class="carousel-caption d-none d-md-block">
                    <h2 style="color:green">Franco Danelon</h2>
                    <p style="color:green">Me llamo Franco Danelon, trabajo para la empresa PUMA GROUP como analista 
de prevencion de perdidas desde noviembre de 2021.

Actualmente estoy cursando la tecnicatura en programacion en la U.T.N de Pacheco

Me gustan los videojuegos y jugar al paddle.</p>
                </div>
            </div>

        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</asp:Content>
