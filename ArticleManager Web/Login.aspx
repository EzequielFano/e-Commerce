<%@ Page Title="" Language="C#" MasterPageFile="~/MiMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArticleManager_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #contenedorLogin {
            margin-top: 25px;
            text-align: center;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        #ppp {
            background-color: white;
            border-radius: 25px;
        }

        p {
            font-weight: bold;
        }

        #lblPass, #lblUsuario {
            border-radius: 50px;
            height: 39px;
        }

        .textboxlogin {
            border-radius: 50px;
            height: 39px;
            justify-content: center;
            align-items: center;
        }
    </style>

    <%if (!session)
        {%>
    <div class="container" id="contenedorLogin">
        <div class="col-md-4"></div>
        <div class="col-md-4" id="ppp">

            <br>
            <img src="data:image/jpeg;base64,/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBxISEhUTEhAVFRUVFRYXGBUVFRUWFRsVFRUXFhUVFxYYHSggGBolHRUVITEhJSkrLi4uFx8zODMtNygtLisBCgoKDg0OGxAQGy0mICUtLS0tLi0tLS0tLS0tLS0tLS0tLS0tLS0wLS0tLS0tLS0vLy0tLS0tLS0tLS0tLS0tLf/AABEIAOEA4QMBIgACEQEDEQH/xAAcAAEAAQUBAQAAAAAAAAAAAAAAAQIDBAUGBwj/xABDEAACAQIDBAYHBQcBCQEAAAAAAQIDEQQhMQUSQVEGImFxgZETMlKhscHwB0Jy0eEjM1NigpKy8RVDRGODk6LC0hb/xAAbAQEAAgMBAQAAAAAAAAAAAAAABAUBAwYCB//EADIRAAIBAQUFBwQCAwEAAAAAAAABAgMEBRExQRIhUWGhEyJxgZHR8DKxweEj8TNCUoL/2gAMAwEAAhEDEQA/APcQAAAAAAAAQ0EySmTtnyADdtSmnPeLaTbz4d3h3/XjeSsAVAAAAAAAAAAAAAAAjQkGPOTbtwz8ba/X+gBcjVu7FwphGxUAAAAQ0EyQAAAAAAAAAAAAACxa7z4Xy+DuXmSAUxgloSmSa/GbUpU8nK8uUc3+h4qVI047U2kuZ6jCU3hFYmwBzGI6QVHlCO72+t9eRr62MqT9acn2Xy8tCrq3zQjugnLouu/oTYXfUf1NLr9vc7GdeEfWlFd7SLX+0KP8SPmcXdaAiO+5vKC9cfwiQrthrJ/PU7T/AGhR/iR8y5HEwek4vukmcSQYV91NYL1a9w7thpJ9DvgcNQxE4erOUfF28jPw+3asfWtNduT81l7iXSvmjL64uPVe/Q0Tu+a+lp9P11OqBrMJtilPK+6+UtPB6GyLSlVhVjtQaa5fNxCnTlB4SWBaqX07rfMrjTS4FYNh4IuSCNACQCmUktQCoEEgAAAAAAAAAAAAAxcZjYUleb7ktX3IxdqbUVJWWc3w4Ltf5HMVq0ptyk22+L+siqt15Ro9yG+XRePF8vUm2axup3pbl9zOx216lTJdSPK+b8TXgtV60YRc5yUYxV23okjm6tWpWltTeL+ZaLyLiEI01hFYIrZYp4uMk3CSkk2rp3V1k8+Nn8Gjg9p7dq42tGhSbhSnLdsvWcfvSl2JJvd87m12n0mo4aKo4eKm4Ky9iNuDa9Z80vM3uyTWC/2e/DgubyzMdojq4Q4soq4ynH1qsI/ilFfFnle0NuYit+8rSt7MXux/tWvjc18Y3dks2SI3c39UvRfk8drwR7FTx9GXq1qb7pxfwZlHlmB2XhlnisVGP/LpftJd0pRTS7szpNn7f2dh1u0lNLnuzbfjJmipZcP8eMv/ADu9cT2qnE68g0FLphg3/vHH8UJ/JM2+Dx9Kr+7qwnbVRkm13rVEaVKcPqTXkz0pJmVYy8FtSpS0d4+zw8ORhNgzTqypy2qbwfIxKCmsJLFHYYHaEKq6rtLjF6/qjOOChNppptNaNanSbJ2tv2hPKfB8JfkzobDeiqvYq7paPR+z6cCptNicO9DL7G5AKZSsXBAInOxajHezemfEbrlx1yfgy+ASAAAAACEySGiHK2oBUQmWIycndaZcTIABq9r7SVJWWc3p2LmzKx2KVKDk/Bc3yOOr1nOTlJ3b1Kq8rd2MdiH1PouPi9PUm2Ozdo9qWS6lMpNttu7erfEAg5cuy3KtFTUL9aSlJLsi4p/5I4b7QNquU1h4vqxtKfbJ5xT7lZ+PYZnSTabo46jPPdhTzS4xnJqdvBRfekcjtbE+lrVJ+1OT8L9X3FpY7NhJVHlhivHH23/0aJz3YGLTqOLvFtOzV1rZqzXiikAszSAAAACm5kFRO+8nfNaNZNeJBVTnZ3sn2NXXkYB0Gx+mFelZVP2sP5vXXdLj4+aO92XtOliIb9KV1xWkovlJcDzvAbehDKpgMLNc1TjGXm00/I7Do/i8DVlvUKcKdS2cVFU5245RykvMqLXSwTlsYc1hh5o303pidASQEivwxNx0mxdqb/Um+stH7S/M27V1nocMnazTs1mnxvzOs2XjvSwu/WWUl8+5nS3ZbnVXZVH3lk+K911Xg2U1ssyh345a8jPSJALggEaEghAEgo9Iua8wATKVlcsyu3o9ezR6lc4X09/x7y4kAEiSGjA2tivR05Nes+qu9/krs8VKipxc5ZJYnqEXOSitTRbbxnpKlk+rC9u18frsNeAcTWqyqzc5Zv50W7yOjpwUIqK0ASKSW8jWezz/AO0Wm1XhLhKnbxjJ/wD0jl50mlGTWUr2f4XZrvWWXauZ2PTDH4bEUepVXpaUvUkpQlZ9WcbSSz0f9JrujuBeKw+Iw8VepDdr0lkm5LqVI3eXWjuLvS5F9ZW+ySa3rcRKmCeJzhXQoym92EZSl7MU5PyWZ6PsD7O6cUp4uW/L+HFtQXZKSzk+6y7ztcJhKdKO7SpxhHlCKivcb3NGl1EjxvD9EcdPNYWa/E4w902mZP8A+Ex/8GP/AHKf5nsRTJXyPO2zz2jPFa/Q/Hx/4WTX8sqctOxSuazFYGrS/e0p0/xwlH3tHvkI2RMldWeg2wqrPnsHs+0uiGDr33qChJ/fpdR99l1X4pnG7Z+zqtC8sPNVo+xK0Kng/Vl7u49KaPaqJnFFVKUk04tqV1bdvvX4WtncnEUJ05OE4ShJaxkmmvBm26NbQw9CfpK0JykvV3VFxj/NZtXfwE5OKbSxfBGxHo+yI1fQw9O06m71mlbPk7cbWvbjczS1h629FSs1dXtJWkr81wZcObb3ktIGTs3GOlUUuGkl3/VzFBmnOVOSlHNb0YlFSTi8md4nyKjUdHsVvU916wy/p4fNeBtztaFZVqaqR1Xz0yOcq03Tm4vQFqcuC7NO8uMtwp2+C7vzNx4LXo17MvJAygAAAADmOkte9RRX3V75fpbzOnOHx1XfqTlzk/Lh7rFRfNXZoKH/AE+i3/fAn3fDGo5cF993uWEUznYVJctSKceJzRcFaKgDBk4Xp9sezWJgtWo1EuekZ/J+Bj/ZlO2NS9qlUX+Mvkd1jMNGrTlTl6s4uL8ePecV9nWFlHaEoy1p06qfepRh8y3sNbbpuDzX2/T3EWvHBNnqxIBJIQsAQAAAYAaCBEpWMg81+1qp+1oLlTm/OSXyNT0G2P6ap6WavCk1ZPSVTVLw18jafarTfpKEtbwnHxUovL+46PYOAVChCnxSvL8bzl78vBGi11uzpJLN/GS6EcUjYgApSYCCQZBn7Dr7laPKXVfjp77eZ1xwdNtNNap3Xes0dxSnvJNcUn5o6O5auMJU3o8V4P8Aa6lReMMJKXH8FwAF0VwAAAAABZxE92Epcot+SOGemR2m03+xn+FnFnO328akFyfXD2Le7V3JPn8+5RCP1xK7FQKTEsSlFRSwmAbPAJbni7nPYTA+i2vVkllWw2+uW9GdOM17ov8AqN1gKtnuvjp3l2vQUqlOotYOUW+O5Ujmv7o034FzZZp0lh4FbVTjN46mWgAbzUCAAACQYBBbim3n4/oXLEmQcr0pwCrYzAQtkp1akvw01Tln2NqK8To8SluO64FCw163pGtKe5H+qW9PztT/ALSjaFXLd8X8jVXmo023w+5sppykkjCBSiopCzBCI3uAQBU2dfsme9Rh3W/tdvkcgdT0ff7Bdjl8blvc0n27XGL6NEC8V/EvH8M2gIZJ0xTAAAAAAGJtP9zP8LONO2xcbwmucZLzTOIOcvtfyQfJ9H+y3u59yS5/gkAFIWIKSotSd8uGZlAhzvkviZ2Gxe6rSV+3iYkY656kpmyFWUH3GeJQjL6jdpgx8DUvG3FZfkZBcwmpxUlqVkouLaYJIJPRgAEGTAJBaxNTdi35d55lJRWLPSTbwRjV8bwivF/Iwm7kgpalWVR4yLOFOMMikonPgiZy5dnvEYdvP3ng9MQhbvLhTcqMMyDqej/7ld7+Jyx12xoWoQXY35tv5ltc0X27fCL+6IF4v+JLn+GZ5FiQdOUwAAAAAAOGxVLcnKPsyfknkdycr0hobtXe4TV/FZP3FPfNLaoqf/L6P94Fhd88JuPH8fGawEEpHNYFwUhRzuSyQAUsqBgFeGrbrvw4m2TvmjSNGVhMRu3T017SdY62D2NGRbTS3bRsiEWqbu73yLxZkIgkAwAavGVt55aL6uXsbiOC04v5GEV9tq7+z9SZZqf+5JSypIhsgEshx9xUAAUsJlRSwCUr6Hc0KW7GK5JLyVjk9jUd6rG+ie8/DT3nUtuTy0+rM6G5KWEJ1OLS9P76FTeM8XGC03+pfJALwrQAAAAAAazbmG36Ta1h1l3cV5fA2ZBrq0o1YOEsmsPnge6c3CSktDgyGZu18J6Ko0vVece7ivD8jDOJq05U5OEs1uOihJTSksmAQWq1ZQV5NJdvy5mIQlOSjFNt5JJtvwS3szKSisZPBE4ivGEXOclGMVdt6JI86290qq124026dLkspy7ZNady95sOm+0JVYxjTTdJO8nxcvu3Xsr49yOOOksV1Ss/etEcJ5pPRcfH1wy3PHCntFtVbdSljHitfMpjtHEYfrUK04LjFO8L89x3j7j0j7M9v18b6ZVow/Z+jW9FNXU9+6au193hbXQ84lG56H9jtGMKeJV1d1IZXz3VF2bXK7kvAk2qjT2XPZW1xw3mmjOSeynu4HcSbg8s4lyOJj3F2cbmFVoNZrT4d5BzJBkyxMeZj1sQ3loiyDKQOc6d7aq4TDxqUowcpVFDrptJOMneyau+qeaVNr4rFO9evNwv6i6sH2OMbJrvueifaZRUsFZtJ+lp2vxed7c3ZtnnKslZKxMs1Gnht7K2uOu7LDh5EerOX047uButj9I62HaSlv0+NN6W/kf3e7TsPRtn46FemqlN3i/NPimuDR48dP0Jxs6U5XTdKS634lo49vB+HJGq2XW7TvoRxnwWvHljrj5cDbZ7YqG6o+7z0+cPQ9EBYw+KhU9WSfZx8UXzmalOdKbhUi1JZppprxT3lzCcZxUotNPVb0ClsqLmDwrqzUFlnrySPMIuTUY5vcjMpKKxZuej+Ge46lvX9XuT4rtfwRvoq2RRRpKMVFKySt5Fxo7Wz0VRpRprT76vzeJzlWo6k3N6kghMk3msAAAgkGNOd3k+NtfrIAr9JnZaF4ohCxWAYO08GqsGvvLOL7eXczkJwabTVmnZrtO9NNtrZm+vSQXXSzXtJfMp71sTqR7WC7yW9cV7rT0LCxWnYexLJ9Di9p7QVJWWc35Jc2c3Xqyk96Tbfb9aFWKqucnJ6t+X+mhQkd1c9z0ruopJfyNd6WreqT/5TyWub35cveFvna5449xfSvy+ev2Kd2+RpNq7H3etSV1xjq12rs7Dft2X17ygn2my07RHZn5PVESjXnRljHz5nFGbsbalTC1Y1abzWTT0lF6xfY/yfA2+0dlRqdaPVl7n39vac9XoSg7SVn9aczlrXYqlB4T3p66P2fIvaFqhW+nc+Gv78uh7psbalPFUo1aTyeqesZLWMu1fkzNaPEujHSCeDq70etCVlUhzXNcpLg/A9l2fjadenGrSkpQkrp/FNcGtGigrUXTfIs6c9pcy46UXw+Ri4+vSowlUm1GMVdt3aX5vRW7S/isRGEXKUlFRTcpNpJJankfS7pK8XPdhdUYvqrNOT035J+5cO9sxRpOo+QnNRRidJtuzxlXfa3YRypw9mPb/ADPV+XA1JVTpuTtFNt8Eb3Z+x1HrVM37PBd/Nl9ZLHOs9mmty10Xzgv2V1e0wpLGb38NX84vAwtm7LdS0pZQ977uS7ToYQUUklZLRIkHVWWx07PHCOer1f65f2UNe0TrPGWXDgVQm07p2a46M6DZO09/qT9bg+f6nPFyL3c1k1xI16XVQvCl2dRd7/WWsX7Y5x1zzSa3WK3VLJPajlqtH+8Mnn9js7HUbEwHooXkuvLXsXBGB0dwG8o1pq10nGL5vPe/LzOjPn923fKk3UqrCWSXDi/bl47uttlqU1sQe7XmAAXJXENBMkoqTsAVgxLP21/d+gALta/h8+HgVqPmVJEgEMkEAEgFMpWAOS6V9FVWvWopKrrKOin29kvj7zz+rBxbi0007NNNSTWt09Ge3amk270do4pXa3KiWVSOvdJfeX0mi3sV5unhCrvjo9Vy5rr47ivtNi23tQz4cTyi4NntjYNfDP8AaRvHhUjnF8s/uvsfvNWdDCcZx2ovFcSolFxeElgwW69CM1aUU19aPgXSDMoqSweRhPB4o0GN2LKOdN7y5fe/Uv8ARfpHUwVR5N05Nekp6P8AFG+k0vPR8GtzYx8Tg4VPWjft0fmUlruanUT7J4cnl65osrPeUo/Xv56/voY/S/pVLFv0dO8aCeSeUpu+sly5R8dbW1mD2POecuou31vLh4m5wuBp0/Vjnzecv08DJPNjuSEEu1ePJZebzflh5nq0XlKX+P1f4RYwuFhTVoq3N8X3syCAXsYqKUYrBIq3Jt4vMAMzdlbKrYmW7Rg3Z5yeSj+KXDu1MSkorGTwQinJ4IxY/XjpY7fop0RatWxMe2NJ+5zX/r58jbdHuitLDWnL9pV9prKP4F83n3aHSFDbb02k4UcuPt75+BbWaw7PeqZ8PcAApSyAAABZhF3d+zzXHuLtiQCjcXJArAAAAAAKZysrgETlZFqMXJ3fz+vpk7rd87a9319d12KsrAEpEgAFE4JpppNPVPNWOY2t0Kw9W8qbdGX8qvD+zh4NHVA20q9Si8acsPnDJ+Z4qU4VFhJYnlW0OiGLpZqn6SPODv8A+L63kmaWVJxdppxfKSafime3lmvQhNWnGMlykk15MtKd8zS78U/Dd7ogzu6L+iTXjvPE5SIPW8R0awktcND+m8P8WjDfQvB/wpLuqS+bJcb4s+ql6L3I7u6ro119meXg9QXQvB+xN/8AUl8mZNDovg46YeL/ABOU/wDJsy74s+il6L3MK7qurXX2PJ4q7sld8lm/I3OB6LYqr/unCPtT6q8n1n5HqOGwkKatTpwguUIqPwJvvPstz0z4oi1b5b3U4+u/2/JvhdqX1yx8N3zoclsvoRTi060nUfsq8YePF+7jkddh6EacVGEVGK0UUkl4IuRha/aVJlVWtFWs8aksft6ZE+nShTWEFgSADSbAAAAAAAAAAAAAAAAQSACmKtkioAAgkEWAJBanU5ak0YWXeAXAAAAAAAAAQEiQACGiQAQmSQ0UTqJd/IAuEIs0027v4F8AAAAhskEJAEgAAAAAAAAAAAAAAx4+t4v4MyAAAAAAAAAAAAAAAAAAY9fXw+TAAMgAAAAAAAAAAAH/2Q==" style="height: 130px; width: 130px;"><br>
            <br>
            <br>
            <div class="col text-start" style="margin-left: 10px;">
                <label id="lblUsuario" style="color: black" class="form-label text-start"><b>Usuario</b></label>
            </div>
            <asp:TextBox CssClass="form-control textboxlogin" ID="txtUser" runat="server" />
            <br>
            <div class="col text-start" style="margin-left: 10px;">
                <label id="lblPass" style="color: black; font-weight: bold;" class="form-label text-start"><b>Contraseña</b></label>
            </div>
            <asp:TextBox type="Password" CssClass="form-control textboxlogin" ID="txtPassword" runat="server" />
            <br>
            <div class="row">
                <div class="col-md-6">
                </div>
            </div>
            <br>
            <asp:Button ID="btnIngresar" CssClass="btn btn-outline-success buttoncolor" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            <br>
            <br>

            <br>
        </div>
        <div class="col-md-4"></div>
    </div>



    <%}
        else
        { %>
    <div class="container">
        <div class="d-flex justify-content-center mt-4">
            <asp:Label ID="lblUser" CssClass="align-content-center " BackColor="white" BorderColor="Black" Font-Size="XX-Large" runat="server"></asp:Label>
        </div>
    </div>
    <div class="container">
        <div class="d-flex justify-content-center mt-4">
            <h3 style="color: white">Te logueaste exitosamente a nuestro carrito de compras</h3>

        </div>
    </div>
    <br />
    <div class="container">
        <div class="d-flex justify-content-lg-evenly">
            <asp:Button ID="btnCerrarSesion" runat="server" CssClass="btn btn-success" Text="Cerrar sesion" OnClick="btnCerrarSesion_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Comenzar a comprar" CssClass="btn btn-success" OnClick="btnVolver_Click" />
        </div>
    </div>

    <%}%>
</asp:Content>

