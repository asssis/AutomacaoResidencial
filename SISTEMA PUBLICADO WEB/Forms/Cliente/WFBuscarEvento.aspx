<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFBuscarEvento.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFBuscarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfMenu" EnableViewState="true" runat="server" />
        <div class="tela-controle" id="divVisualizacaoAgendamento" runat="server"></div>
        <div class="tela-simples" id="divMenuPrincipal" runat="server">    
        </div>
</asp:Content>
