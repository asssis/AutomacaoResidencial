<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFControle.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFControle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="tela-controle" id="divVisualizacaoControle" runat="server"></div>
        <div class="tela-simples">
            <a class="a-toch-dois-terco ativo-amarelo" href="WFBuscarEvento.aspx">AGENDAMENTO</a>
           <a class="a-toch-um-terco ativo" href="WFConsumo.aspx">CONSUMO</a>
             <a class="a-toch-um-terco ativo" href="WFDispositivo.aspx">VOLTAR</a>
            <a class="a-toch-um-terco ativo" href="WFControle.aspx">ATUALIZAR</a>
            <a class="a-toch-um-terco ativo" href="WFUnidade.aspx">HOME</a>
        </div>
</asp:Content>
