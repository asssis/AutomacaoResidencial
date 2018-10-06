<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFManterControle.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterControle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio bloco-inteiro">
        <h2>Cadastro Controle</h2>
        <h3>Dados Controle</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Controle</p>
            <asp:TextBox ID="txtMatricula" Enabled="false" AutoPostBack="true" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnPesquisar" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar" />
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Equipamento</p>
            <asp:DropDownList ID="ddlEquipamento" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>LAMPADA</asp:ListItem>
                <asp:ListItem>AR CONDICIONADO</asp:ListItem>
                <asp:ListItem>TELEVISÃO</asp:ListItem>
                <asp:ListItem>ABAJÚ</asp:ListItem>
                <asp:ListItem>TOMADA</asp:ListItem>
                <asp:ListItem>VENTILADOR</asp:ListItem>
                <asp:ListItem>REGISTRO</asp:ListItem>
                <asp:ListItem>BOMBA</asp:ListItem>
                <asp:ListItem>CORTINA</asp:ListItem>
                <asp:ListItem>JANELA</asp:ListItem>
                <asp:ListItem>PORTA</asp:ListItem>
                <asp:ListItem>PORTÃO</asp:ListItem>
                <asp:ListItem>FECHADURA</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Marca</p>
            <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Modelo</p>
            <asp:TextBox ID="txtModelo" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Consumo</p>
            <asp:TextBox ID="txtConsumo" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Controle</p>
            <asp:DropDownList ID="ddlControle" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>SIMPLES</asp:ListItem>
                <asp:ListItem>LOGICO</asp:ListItem>
                <asp:ListItem>GRADUAL</asp:ListItem>
                <asp:ListItem>ESPECIFICO</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="grupo-botoes-center">
            <asp:Button ID="btnGravar" CssClass="btn-gravar" OnClick="btnGravar_Click" runat="server" Text="Gravar" />
            <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" OnClick="btnNovo_Click" Text="Novo" />
            <asp:Button ID="btnDeletar" CssClass="btn-deletar" runat="server" Text="Deletar" />
            <asp:Button ID="btnBuscar" CssClass="btn-buscar" runat="server" Text="Buscar" />
        </div>
    </div>
</asp:Content>
