<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFRelatorioMensal.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFRelatorioMensal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Graficos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tela-controle" id="divVisualizacaoDivisao" runat="server">

        <div class="grafico">
            <p>01-05</p>
            <div id="colDom" runat="server"></div>
            <p>06-12</p>
            <div></div>
            <p>13-19</p>
            <div></div>
            <p>20-26</p>
            <div></div>
            <p>27-31</p>
            <div></div>
        </div>

    </div>
    <div class="tela-simples">
        <a class="a-toch-um-terco ativo-amarelo" href="WFUnidade.aspx">ANTERIOR</a>
        <a class="a-toch-um-terco ativo" href="WFUnidade.aspx">SEMANAL</a>
        <a class="a-toch-um-terco ativo-amarelo" href="WFUnidade.aspx">PROXIMO</a>
        <a class="a-toch-um-meio ativo" href="WFUnidade.aspx">VOLTAR</a>
        <a class="a-toch-um-meio ativo" href="WFUnidade.aspx">HOME</a>
    </div>
</asp:Content>
