<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProgramacionIV.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Iniciar sesión</h2>
            <asp:Label runat="server" AssociatedControlID="txtUsuario" Text="Usuario" />
            <asp:TextBox runat="server" ID="txtUsuario" />
            <br />

            <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Contraseña" />
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" />

            <br />
            <asp:Button runat="server" ID="btnLogin" Text="Ingresar" OnClick="btnLogin_Click" />
            <br />
            <asp:Label runat="server" ID="lblError" ForeColor="Red" />
        </div>
    </form>
</body>
</html>
