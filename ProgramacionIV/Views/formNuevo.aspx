<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formNuevo.aspx.cs" Inherits="ProgramacionIV.formNuevo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2>Formulario de Estudiantes</h2>

        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" />

        <div class="form-group">
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"
                ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido"
                ErrorMessage="El apellido es obligatorio." CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="form-group">
            <label for="txtCorreo">Correo electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="El correo es obligatorio." CssClass="text-danger" Display="Dynamic" />
            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo"
                ErrorMessage="Formato de correo inválido." CssClass="text-danger" Display="Dynamic"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
        </div>

        <div class="form-group">
            <label for="ddlCarrera">Carrera:</label>
            <asp:DropDownList ID="ddlCarrera" runat="server" CssClass="form-control">
                <asp:ListItem Text="Seleccione una carrera" Value="" />
                <asp:ListItem Text="Ingeniería en Sistemas" Value="Sistemas" />
                <asp:ListItem Text="Administración" Value="Administracion" />
                <asp:ListItem Text="Psicología" Value="Psicologia" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvCarrera" runat="server" ControlToValidate="ddlCarrera"
                InitialValue="" ErrorMessage="Debe seleccionar una carrera." CssClass="text-danger" Display="Dynamic" />
        </div>

        <div class="form-group mt-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" />
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-secondary" CausesValidation="false" />
        </div>

    </main>
</asp:Content>
