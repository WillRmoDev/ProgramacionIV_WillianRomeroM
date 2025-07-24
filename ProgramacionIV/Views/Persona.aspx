<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Persona.aspx.cs" Inherits="ProgramacionIV._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 runat="server" id="mensajeDesdeServicio"> </h1>
            <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
            <p><a href="http://www.asp.net" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">

            <div class="container mt-5">
                <h2 class="mb-4">Insertar Persona</h2>

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtApellidos" class="form-label">Apellidos</label>
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label class="form-label d-block">Sexo</label>
                    <div class="form-check form-check-inline">
                        <asp:RadioButton ID="rbMasculino" runat="server" GroupName="Sexo" CssClass="form-check-input" />
                        <label class="form-check-label" for="rbMasculino">Masculino</label>
                    </div>
                    <div class="form-check form-check-inline">
                        <asp:RadioButton ID="rbFemenino" runat="server" GroupName="Sexo" CssClass="form-check-input" />
                        <label class="form-check-label" for="rbFemenino">Femenino</label>
                    </div>
                </div>

                <div class="mb-3">
                    <label for="ddlNacionalidad" class="form-label">Nacionalidad</label>
                    <asp:DropDownList ID="ddlNacionalidad" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccione" Value="" />
                        <asp:ListItem Text="Costarricense" Value="CR" />
                        <asp:ListItem Text="Nicaragüense" Value="NI" />
                        <asp:ListItem Text="Estadounidense" Value="US" />
                        <asp:ListItem Text="Otro" Value="OTRO" />
                    </asp:DropDownList>
                </div>

                <div class="mb-3">
                    <label for="txtEdad" class="form-label">Edad</label>
                    <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" TextMode="Number" />
                </div>

                <div class="mb-3">
                    <label for="txtCorreo" class="form-label">Correo Electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
                </div>

                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            </div>

        </div>       
    </main>

</asp:Content>
