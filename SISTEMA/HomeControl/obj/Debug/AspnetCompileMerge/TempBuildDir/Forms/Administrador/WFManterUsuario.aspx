<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPAdministrador.Master" AutoEventWireup="true" CodeBehind="WFManterUsuario.aspx.cs" Inherits="HomeControl.Forms.Administrador.WFManterUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="inicio bloco-inteiro">
        <h2>Cadastrar Usuario</h2>
        <h3>Dados Usuario</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Usuario</p>
              <asp:TextBox ID="txtUsuario" AutoPostBack="true" Enabled="false" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
              <asp:Button ID="btnBuscarUsuario" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar"/>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Login*</p>
            <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Nivel*</p>
            <asp:DropDownList ID="ddlNivel" runat="server">
                <asp:ListItem></asp:ListItem>                
                <asp:ListItem>ADMINISTRADOR</asp:ListItem>
                 <asp:ListItem>TECNICO</asp:ListItem>
                <asp:ListItem>CLIENTE</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Estado*</p>
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem></asp:ListItem>                
                 <asp:ListItem>DESATIVADO</asp:ListItem>
                <asp:ListItem>ATIVADO</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Senha*</p>
            <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Repita Senha*</p>
            <asp:TextBox ID="txtRepitaSenha" runat="server" TextMode="Password"></asp:TextBox>
        </div>

        <h3>Dados Pessoais</h3>
        <div class="controle-um-meio controle-inicio">
            <p>Nome*</p>
            <asp:TextBox ID="txtNome" name="Nome" runat="server"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Cpf/Cnpj*</p>
            <asp:TextBox ID="txtCpfCnpj" runat="server" OnKeyPress="MascaraCpf(this)" MaxLength="14"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-inicio">
            <p>Telefone*</p>
            <asp:TextBox ID="txtTelefone" runat="server" OnKeyPress="MascaraTelefone(this)" MaxLength="14"></asp:TextBox>
        </div>
        <div class="controle-um-meio controle-fim">
            <p>Email*</p>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>

        <div class="grupo-botoes-center">
            <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            <asp:Button ID="btnGravar" CssClass="btn-gravar" runat="server" Text="Gravar" OnClick="btnGravar_Click" />
            <asp:Button ID="btnDeletar" CssClass="btn-deletar" runat="server" Text="Deletar" OnClick="btnDeletar_Click" />
            <asp:Button ID="btnBuscar" CssClass="btn-buscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />            
                </div>
    </div>

</asp:Content>
