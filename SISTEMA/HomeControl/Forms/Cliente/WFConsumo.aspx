<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFConsumo.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFConsumo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/Graficos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:HiddenField ID="hfDia" runat="server" />
    <div class="tela-controle" id="divVisualizacaoConsumo" runat="server">
        <asp:Label ID="lblTitulo" runat="server" CssClass="titulo"></asp:Label>
        <asp:LinkButton ID="lkbHome" runat="server" CssClass="subtitulo">HOME</asp:LinkButton><p class="subtitulo">/</p>
        <asp:LinkButton ID="lkbUnidade" runat="server" CssClass="subtitulo">UNIDADE</asp:LinkButton><p class="subtitulo">/</p>
        <asp:LinkButton ID="lkbDivisao" runat="server" CssClass="subtitulo">DIVISÃO</asp:LinkButton><p class="subtitulo">/</p>
        <asp:LinkButton ID="lkbDispositivo" runat="server" CssClass="subtitulo">DISPOSITIVO</asp:LinkButton><p class="subtitulo">/</p>
        <asp:LinkButton ID="lkbConsumo" runat="server" Enabled="false" CssClass="subtitulo">CONSUMO</asp:LinkButton>
        <asp:Label ID="lblSubTitulo" runat="server" CssClass="subtitulografico"></asp:Label>
        <div class="grafico" id="grafConsumo" runat="server">            
        </div>
        <asp:Label ID="lblRecurso" runat="server" CssClass="lblrecurso"></asp:Label>
    </div>
    
    <div class="tela-simples">
          <asp:Button CssClass="a-toch-um-terco ativo-amarelo" ID="btnAnterior" runat="server" Text="ANTERIOR" OnClick="btnAnterior_Click" />
         <asp:Button CssClass="a-toch-um-terco ativo" ID="btnBuscar" runat="server" Text="ENERGIA" OnClick="btnBuscar_Click" />
          <asp:Button CssClass="a-toch-um-terco ativo-amarelo" ID="btnProximo" runat="server" Text="PRÓXIMO" OnClick="btnProximo_Click"/>
        <a class="a-toch-um-meio ativo" href="WFDispositivo.aspx">VOLTAR</a>
        <a class="a-toch-um-meio ativo" href="WFUnidade.aspx">HOME</a>
    </div>
</asp:Content>
