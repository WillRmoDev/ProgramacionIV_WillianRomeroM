<%@ Page Title="Gestion Materias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="ProgramacionIV.Views.Materias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container">
        <div class="row g-1">

            <div class="col-md-6">
                <h2 class="mb-4">Insertar Materia</h2>

                <div class="mb-3">
                    <label for="txtId" class="form-label">ID</label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="false" />
                </div>    

                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtCodigo" class="form-label">Apellidos</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="txtCreditos" class="form-label">Correo Electrónico</label>
                    <asp:TextBox ID="txtCreditos" runat="server" CssClass="form-control" TextMode="Email" />
                </div>

                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" />
            </div>
            <div class="col-md-6">
                <h2 class="mb-4">Lista de Materias</h2>
                <asp:GridView ID="gvMaterias" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="gvEstudiantes_acciones" DataKeyNames="EstudianteID">
                    <Columns>
                        <asp:BoundField DataField="MateriaID" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="Creditos" HeaderText="Creditos" />
                        <asp:ButtonField ButtonType="Button" CommandName="Seleccionar" Text="Seleccionar" />
                        <asp:ButtonField ButtonType="Button" CommandName="Eliminar" Text="Eliminar" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </main>
</asp:Content>
