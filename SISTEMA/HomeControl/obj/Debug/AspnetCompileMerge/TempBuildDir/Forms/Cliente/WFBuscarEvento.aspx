<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFBuscarEvento.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFBuscarEvento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="tela-controle" id="divVisualizacaoAgendamento" runat="server"></div>
        <div class="tela-simples">
            <asp:Button CssClass="a-toch-um-inteiro ativo" ID="btnCriarAgendamento" runat="server" OnClick="btnCriarAgendamento_Click" Text="CRIAR AGENDAMENTO" />
            <a class="a-toch-um-meio ativo" href="WFControle.aspx">VOLTAR</a>
            <a class="a-toch-um-meio ativo" href="WFUnidade.aspx">HOME</a>
        </div>
</asp:Content>
