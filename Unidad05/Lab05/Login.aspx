<%@ Page Language="C#" MasterPageFile="~/Lab05MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Lab05.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageContent" runat="Server">
    <div>
        <asp:Label ID="lblBienvenido" runat="server" Text="Bienvenido al Sistema"></asp:Label>
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
        <asp:TextBox ID="txtClave" runat="server"></asp:TextBox>
        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        <asp:LinkButton ID="lnkRecordarClave" runat="server" Text="Olvide mi clave" OnClick="lnkRecordarClave_Click"></asp:LinkButton>
    </div>
</asp:Content>
