<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFUnidade.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFUnidade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="tela-controle" id="divVisualizacaoUnidade" runat="server"></div>
        <div class="tela-simples">
            <asp:Button ID="_btnSair" CssClass="a-toch-um-meio ativo" OnClick="btnSair_Click" runat="server" Text="SAIR" />
            <a class="a-toch-um-meio  ativo" href="WFUnidade.aspx">HOME</a>
        </div>
</asp:Content>
