<%@ Page Title="Gestion Estudiantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="ProgramacionIV.Views.Estudiantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">
        <div class="row g-1">

            <div class="col-md-6">
                <h2 class="mb-4">Insertar Estudiante</h2>

                <div class="mb-3">
                    <label for="txtId" class="form-label">ID</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="false" />
                </div>    

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtApellidos" class="form-label">Apellidos</label>
                    <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtCorreo" class="form-label">Correo Electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
                </div>

                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha Nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" TextMode="Date" />
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            </div>
            <div class="col-md-6">
                <h2 class="mb-4">Lista de Estudiantes</h2>
                <asp:GridView ID="gvEstudiantes" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvEstudiantes_acciones" DataKeyNames="EstudianteID">
                    <Columns>
                        <asp:BoundField DataField="EstudianteID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Correo" HeaderText="Correo" />
                        <asp:ButtonField ButtonType="Button" CommandName="Seleccionar" Text="Seleccionar" />
                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </main>

</asp:Content>
