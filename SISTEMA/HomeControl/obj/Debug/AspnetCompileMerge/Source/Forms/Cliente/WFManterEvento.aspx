<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFManterEvento.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFManterEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfIdEvento" runat="server" /> 
     <asp:HiddenField ID="hfIdAgenda" runat="server" />      
     <asp:HiddenField ID="hfIdDispositivo" runat="server" />
    <div class="tela-controle" runat="server">
        <label class="titulo">AGEDAMENTO</label>
        <asp:Button ID="btnSair" runat="server" Text="X" OnClick="btnSair_Click" CssClass="btn-touch-sair" />
        <asp:TextBox ID="txtHora" OnKeyPress="MascaraHora(this)" MaxLength="5" CssClass="txthora" runat="server"></asp:TextBox>
        <div class="chgruposemana">
            <div class="divchsemana">
                <p>D</p>
                <asp:CheckBox ID="chDom" runat="server" />
            </div>
            <div class="divchsemana">
                <p>S</p>
                <asp:CheckBox ID="chSeg" runat="server" />
            </div>
            <div class="divchsemana">
                <p>T</p>
                <asp:CheckBox ID="chTer" runat="server" />
            </div>
            <div class="divchsemana">
                <p>Q</p>
                <asp:CheckBox ID="chQua" runat="server" />
            </div>
            <div class="divchsemana">
                <p>Q</p>
                <asp:CheckBox ID="chQui" runat="server" />
            </div>
            <div class="divchsemana">
                <p>S</p>
                <asp:CheckBox ID="chSex" runat="server" />
            </div>
            <div class="divchsemana">
                <p>S</p>
                <asp:CheckBox ID="chSab" runat="server" />
            </div>
        </div>
        <div runat="server" id="divVisualizacaoAgendamento" class="divnula">
        
        </div>
    </div>
    <div class="tela-simples">
        <asp:Button CssClass="a-toch-um-inteiro ativo" ID="btnManterAgendamento" OnClick="btnManterAgendamento_Click" runat="server" Text="GRAVAR" />
        <a class="a-toch-um-meio ativo" href="WFBuscarEvento.aspx">VOLTAR</a>
        <a class="a-toch-um-meio ativo" href="WFUnidade.aspx">HOME</a>
    </div>
</asp:Content>
