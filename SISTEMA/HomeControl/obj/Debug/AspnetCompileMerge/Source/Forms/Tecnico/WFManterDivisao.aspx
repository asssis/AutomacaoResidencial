<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFManterDivisao.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterDivisao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfDivisao" runat="server" />
        <div class="inicio bloco-inteiro">
            <h2>Cadastro Divisão</h2>
            <h3>Dados Divisão</h3>
            <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                <asp:TextBox ID="txtMatricula" runat="server" Enabled="false" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnPesquisarDivisao" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar"/>
         
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Descrição</p>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
            </div>
            <h3>Dados Unidade</h3>
             <div class="controle-um-meio controle-inicio">
                <p>Unidade</p>
                <asp:TextBox ID="txtUnidade" AutoPostBack="true" OnTextChanged="txtMatricula_TextChanged" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnPesquisar" CssClass="btn-pesquisa" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar"/>
            </div>
                  
            <div class="controle-um-meio controle-fim">
                <p>Descricao</p>
                <asp:TextBox ID="txtDescricaoUnidade" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Cep</p>
                <asp:TextBox ID="txtCep" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Endereco</p>
                <asp:TextBox ID="txtEndereco" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Bairro</p>
                <asp:TextBox ID="txtBairro" Enabled="false" runat="server"></asp:TextBox>
            </div>            
            <div class="controle-um-meio controle-fim">
                <p>Numero</p>
                <asp:TextBox ID="txtNumero" Enabled="false" runat="server"></asp:TextBox>
            </div>                  
            <div class="controle-um-meio controle-inicio">
                <p>Cidade</p>
                <asp:TextBox ID="txtCidade" Enabled="false" runat="server"></asp:TextBox>
            </div>
             <div class="controle-um-meio controle-fim">
                <p>Estado</p>
                <asp:TextBox ID="txtEstado" Enabled="false" runat="server"></asp:TextBox>
            </div>      
            <div class="grupo-botoes-center">
                <asp:Button ID="btnGravar" CssClass="btn-gravar" runat="server" Text="Gravar" OnClick="btnGravar_Click"/>
                <asp:Button ID="btnDeletar" CssClass="btn-deletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click"/>
                <asp:Button ID="btnBuscar" CssClass="btn-buscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click"/>          
                <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            </div>
        </div>
</asp:Content>
