<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFRelatorioSemanal.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFRelatorioSemanal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Graficos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tela-controle" id="divVisualizacaoDivisao" runat="server">

    <div class="grafico">   
        <p>DOM</p>        
        <div id="colDom" runat="server"></div>
        <p>SEG</p>
        <div id="colSeg" runat="server"></div>
        <p>TER</p>
        <div id="colTer" runat="server"></div>
        <p>QUA</p>
        <div id="colQua" runat="server"></div>
        <p>QUI</p>
        <div id="colQui" runat="server"></div>
        <p>SEX</p>
        <div id="colSex" runat="server"></div>
        <p>SAB</p>
        <div id="colSab" runat="server"></div>
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
