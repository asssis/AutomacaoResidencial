<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFManterLeitor.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterLeitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio bloco-inteiro">
        <h2>Cadastro Leitor</h2>
        <h3>Dados Leitor</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Matricula</p>
            <asp:TextBox ID="txtMatricula" runat="server" Enabled="false" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnPesquisarLeitor" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar" />

        </div>
        <div class="controle-um-meio controle-fim">
            <p>Nome</p>
            <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
        </div>
         <div class="controle-um-meio controle-inicio">
            <p>Sensores</p>
            <asp:DropDownList ID="ddlTipoLeitor" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>OPTACOPLADOR</asp:ListItem>
                <asp:ListItem>AMPERIMETRO</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Sensibilidade</p>
            <asp:TextBox ID="txtSensibilidade" runat="server"></asp:TextBox>
        </div>

        <div class="controle-um-meio controle-inicio">
            <p>Valor</p>
            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
        </div>


        <div class="controle-um-meio controle-fim">
            <p>Condição</p>
            <asp:DropDownList ID="ddlCondicao" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>MENOR</asp:ListItem>
                <asp:ListItem>MAIOR</asp:ListItem>
                <asp:ListItem>IGUAL</asp:ListItem>
                <asp:ListItem>DIFERENTE</asp:ListItem>
            </asp:DropDownList>
        </div>
        <h3>Dispositivos</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Matricula</p>
            <asp:TextBox ID="txtMatriculaDispositivo" runat="server" OnTextChanged="txtMatriculaDispositivo_TextChanged" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnPesquisarDispositivo" CssClass="btn-pesquisa" runat="server" OnClick="btnPesquisarDispositivo_Click" Text="Pesquisar" />
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Nome</p>
            <asp:TextBox ID="txtNomeDispositivo" runat="server"></asp:TextBox>
        </div>
        <h3>Comandos</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Matricula*</p> 
            <asp:TextBox ID="txtMatriculaComando" runat="server" OnTextChanged="txtMatriculaDispositivo_TextChanged" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
            <asp:Button ID="btnPesquisarComando" CssClass="btn-pesquisa" runat="server" OnClick="btnPesquisarComando_Click" Text="Pesquisar" />

        </div>
        <div class="controle-um-meio controle-fim">
            <p>Nome*</p>
            <asp:TextBox ID="txtNomeComando" runat="server"></asp:TextBox>
        </div>
        <div class="grupo-botoes-center">
            <asp:Button ID="btnGravar" CssClass="btn-gravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
            <asp:Button ID="btnDeletar" CssClass="btn-deletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />
            <asp:Button ID="btnBuscar" CssClass="btn-buscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
        </div>
    </div>
</asp:Content>
