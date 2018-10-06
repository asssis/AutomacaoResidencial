<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPExterno.Master" AutoEventWireup="true" CodeBehind="WFLogin.aspx.cs" Inherits="HomeControl.Forms.WFLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=0.7, maximum-scale=0.7, user-scalable=no">
    <div id="divBlocoLogin" class="bloco-login">
          <h2>Login</h2>
        <div class="controle-um-inteiro">
            <asp:TextBox ID="txtUsuario" PlaceHolder="Usuario" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-inteiro">
            <asp:TextBox ID="txtSenha" PlaceHolder="Senha" TextMode="Password" runat="server"></asp:TextBox>
        </div>
        <asp:Button ID="btnFazerLogin" CssClass="btn-login" OnClick="btnFazerLogin_Click" runat="server" Text="Logar" />
     
        <p class="msnlogin">
            <asp:Label ID="lblMsn" runat="server" ></asp:Label>
        </p>
    </div>    
     <meta />
</asp:Content>
