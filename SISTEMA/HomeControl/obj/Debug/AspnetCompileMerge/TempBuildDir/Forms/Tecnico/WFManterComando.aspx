<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFManterComando.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterComando" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/ControlesPersonalizados.css" rel="stylesheet" />
    <style>
        body {
            background: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="inicio bloco-inteiro">
        <h2>Controle</h2>
        <div class="controle-um-meio controle-inicio">
            <p>Matricula</p>
            <asp:TextBox ID="txtMatriculaControle" AutoPostBack="true" OnTextChanged="txtMatriculaControle_TextChanged" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnPesquisar" OnClick="btnPesquisar_Click" CssClass="btn-pesquisa" runat="server" Text="Pesquisar" />
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Controle</p>
            <asp:TextBox ID="txtControle" Enabled="false" runat="server"></asp:TextBox>
        </div>

        <div class="controle-um-meio controle-inicio">
            <p>Marca</p>
            <asp:TextBox ID="txtMarca" Enabled="false" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Modelo</p>
            <asp:TextBox ID="txtModelo" Enabled="false" runat="server"></asp:TextBox>
        </div>
    </div>

    <div class="invisible" id="divPreVisualizacao" enableviewstate="true" runat="server">
        <h2>Visualização Controle</h2>
        <div class="pre-visualizacao">
            <div class="controle-um-inteiro">
                <div class="tela-controle" id="divVisualizacaoControle" runat="server">
                </div>
                <div class="tela-simples">
                    <asp:Button ID="btnNovoComando" CssClass="a-toch-um-meio ativo-azul" OnClick="btnNovo_Click" runat="server" Text="NOVO" />
                    <asp:Button ID="btnPesquisarControle" CssClass="a-toch-um-meio ativo-azul" OnClick="btnPesquisar_Click" runat="server" Text="BUSCAR" />
                </div>
            </div>
        </div>
    </div>
    <div class="invisible" id="divCadastrarComando" runat="server">
        <h2>Cadastrar Comando</h2>
        <h3>Dados Comando</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Matricula*</p>
            <asp:TextBox ID="txtMatriculaComando" Enabled="false" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Nome*</p>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        </div>

        <div class="controle-um-meio controle-inicio">
            <p>Botao</p>
            <asp:DropDownList ID="ddlBotao" runat="server">
                <asp:ListItem Value="btn-touch-inteiro">INTEIRO</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-meio">METADE</asp:ListItem>
                <asp:ListItem Value="btn-touch-dois-terco">DOIS TERÇO</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco">UM TERÇO</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco-quadrado">UM TERÇO QUADRADO</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco-ce">UM TERÇO RED-CIM-ESQ</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco-cd">UM TERÇO RED-CIM-DIR</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco-be">UM TERÇO RED.BAI.ESQ</asp:ListItem>
                <asp:ListItem Value="btn-touch-um-terco-bd">UM TERÇO RED.BAI.DIR</asp:ListItem>
                <asp:ListItem Value="range-touch-inteiro">INTENSSIDADE</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Comando*</p>
            <asp:TextBox ID="txtComando" AutoPostBack="true" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnLerComando" CssClass="btn-pesquisa" runat="server" Text="Leitura" />
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Cor</p>
            <asp:DropDownList ID="ddlCor" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem Value="ativo-branco">BRANCO</asp:ListItem>
                <asp:ListItem Value="ativo-vermelho">VERMELHO</asp:ListItem>
                <asp:ListItem Value="ativo-amarelo">AMARELO</asp:ListItem>
                <asp:ListItem Value="ativo">AZUL</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Consumo Watts*</p>
            <asp:TextBox ID="txtConsumo" runat="server"></asp:TextBox>
        </div>

        <div class="grupo-botoes-center">
            <asp:Button ID="btnGravar" CssClass="btn-gravar" OnClick="btnGravar_Click" runat="server" Text="Gravar" />
            <asp:Button ID="btnDeletar" CssClass="btn-deletar" OnClick="btnDeletar_Click" runat="server" Text="Deletar" />
        </div>
    </div>
</asp:Content>
