<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" MaintainScrollPositionOnPostback="false" CodeBehind="WFManterUnidade.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterUnidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="inicio bloco-inteiro">

            <h2>Cadastrar Unidade</h2>
            <h3>Dados Unidade</h3>
            <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                <asp:TextBox ID="txtMatricula" Enabled="false" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnBuscar" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar"/>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Descricao*</p>
                <asp:TextBox ID="txtDescricao" name="Descricao" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Tempo Resposta*</p>
                <asp:DropDownList ID="ddlTempo" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>                    
                    <asp:ListItem>3</asp:ListItem>                                      
                    <asp:ListItem>4</asp:ListItem>                                      
                    <asp:ListItem>5</asp:ListItem>                  
                    <asp:ListItem>6</asp:ListItem> 
                </asp:DropDownList>
            </div>

            <h3>Dados Endereço</h3>
            <div class="controle-um-meio controle-inicio">
                <p>Cep*</p>
                  <asp:TextBox ID="txtCep" AutoPostBack="true" runat="server" CssClass="txt-pesquisa-um-meio" OnKeyPress="MascaraCep(this)" MaxLength="9"></asp:TextBox>
                <asp:Button ID="btnPesquisarCep" CssClass="btn-pesquisa" runat="server" Text="Pesquisar" OnClientClick="window.open('http://www.buscacep.correios.com.br/sistemas/buscacep/resultadoBuscaCepEndereco.cfm');"/>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Endereco*</p>
                <asp:TextBox ID="txtEndereco" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Bairro*</p>
                <asp:TextBox ID="txtBairro" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Numero*</p>
                <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Cidade*</p>
                <asp:TextBox ID="txtCidade" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Estado*</p>
                <asp:TextBox ID="txtEstado" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Pais*</p>
                <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
            </div>

            <h3>Dados Usuario</h3>            
            <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                    <asp:TextBox ID="txtMatriculaUsuario" AutoPostBack="true" OnTextChanged="txtMatricula_TextChanged" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                    <asp:Button ID="btnPesquisarUsuario" CssClass="btn-pesquisa" runat="server" OnClick="btnPesquisar_Click" Text="Pesquisar"/>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Nome*</p>
                <asp:TextBox ID="txtNome" Enabled="false" runat="server"></asp:TextBox>
            </div>            
            <div class="controle-um-meio controle-fim">
                <p>Cpf*</p>
                <asp:TextBox ID="txtCpfCnpj" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Telefone*</p>
                <asp:TextBox ID="txtTelefone" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Email*</p>
                <asp:TextBox ID="txtEmail" Enabled="false" runat="server"></asp:TextBox>
            </div>

            <div class="grupo-botoes-center">
                <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
                <asp:Button ID="btnGravar" CssClass="btn-gravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
                <asp:Button ID="btnDeletar" CssClass="btn-deletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />         
            </div>
        </div>
</asp:Content>
