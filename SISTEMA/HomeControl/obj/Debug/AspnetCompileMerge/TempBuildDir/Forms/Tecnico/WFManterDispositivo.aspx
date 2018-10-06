<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFManterDispositivo.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFManterDispositivo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfDivisao" runat="server" />
        <div class="inicio bloco-inteiro">
            <h2>Cadastro Dispositivo</h2>
            <h3>Dados Dispositivo</h3>
              <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                <asp:TextBox ID="txtMatricula" Enabled="false" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnPesquisar" CssClass="btn-pesquisa" runat="server" OnClick="btnBuscar_Click" Text="Pesquisar" />
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Nome</p>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Porta</p>
                <asp:DropDownList ID="ddlPorta" runat="server"> 
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>COM1</asp:ListItem>
                    <asp:ListItem>COM2</asp:ListItem>
                    <asp:ListItem>COM3</asp:ListItem>
                    <asp:ListItem>COM4</asp:ListItem>
                    <asp:ListItem>COM5</asp:ListItem>
                    <asp:ListItem>COM6</asp:ListItem>                    
                    <asp:ListItem>COM7</asp:ListItem>                  
                    <asp:ListItem>COM8</asp:ListItem>                  
                    <asp:ListItem>COM9</asp:ListItem>                  
                    <asp:ListItem>COM10</asp:ListItem>                  
                    <asp:ListItem>COM11</asp:ListItem>                  
                    <asp:ListItem>COM12</asp:ListItem>                  
                    <asp:ListItem>COM13</asp:ListItem>                  
                    <asp:ListItem>COM14</asp:ListItem>                  
                    <asp:ListItem>COM15</asp:ListItem>                  
                    <asp:ListItem>COM16</asp:ListItem>                  
                    <asp:ListItem>COM17</asp:ListItem>                  
                    <asp:ListItem>COM18</asp:ListItem>                  
                    <asp:ListItem>COM19</asp:ListItem>                  
                    <asp:ListItem>COM20</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Pino Entrada</p>    
                <asp:DropDownList ID="ddlPinoEntrada" runat="server"> 
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>                    
                    <asp:ListItem>7</asp:ListItem>                  
                    <asp:ListItem>8</asp:ListItem>                  
                    <asp:ListItem>9</asp:ListItem>                  
                    <asp:ListItem>10</asp:ListItem>                  
                    <asp:ListItem>11</asp:ListItem>                  
                    <asp:ListItem>12</asp:ListItem>                  
                    <asp:ListItem>13</asp:ListItem>                  
                    <asp:ListItem>14</asp:ListItem>                  
                    <asp:ListItem>15</asp:ListItem>                  
                    <asp:ListItem>16</asp:ListItem>                  
                    <asp:ListItem>17</asp:ListItem>                  
                    <asp:ListItem>18</asp:ListItem>                  
                    <asp:ListItem>19</asp:ListItem>                  
                    <asp:ListItem>20</asp:ListItem>
                </asp:DropDownList>
            </div>
               <h3>Controle</h3>
            <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                <asp:TextBox ID="txtMatriculaControle" AutoPostBack="true" OnTextChanged="txtMatriculaControle_TextChanged" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnPesquisarControle" CssClass="btn-pesquisa" runat="server" Text="Pesquisar" OnClick="btnPesquisarControle_Click"/>
            </div>

            <div class="controle-um-meio controle-inicio">
                <p>Equipamento</p>
                <asp:TextBox ID="txtEquipamento" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Marca</p>
                <asp:TextBox ID="txtMarca" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-inicio">
                <p>Modelo</p>
                <asp:TextBox ID="txtModelo" Enabled="false" runat="server"></asp:TextBox>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Controle</p>
                <asp:TextBox ID="txtControle" Enabled="false" runat="server"></asp:TextBox>
            </div>

            <h3>Divisão</h3>
             <div class="controle-um-meio controle-inicio">
                <p>Matricula</p>
                <asp:TextBox ID="txtMatriculaDivisao" AutoPostBack="true" OnTextChanged="txtMatriculaDivisao_TextChanged" runat="server" CssClass="txt-pesquisa-um-meio"></asp:TextBox>
                <asp:Button ID="btnPesquisarDivisao" CssClass="btn-pesquisa" runat="server" Text="Pesquisar" OnClick="btnPesquisarDivisao_Click"/>
            </div>
            <div class="controle-um-meio controle-fim">
                <p>Descricao</p>
                <asp:TextBox ID="txtDescricao" Enabled="false" runat="server"></asp:TextBox>
            </div>
        <div class="grupo-botoes-center">
                <asp:Button ID="btnNovo" CssClass="btn-novo" runat="server" OnClick="btnNovo_Click" Text="Novo"/>
                <asp:Button ID="btnGravar" CssClass="btn-gravar" OnClick="btnGravar_Click" runat="server" Text="Gravar"/>
                <asp:Button ID="btnDeletar" CssClass="btn-deletar" OnClick="btnDeletar_Click" runat="server" Text="Deletar"/>
                <asp:Button ID="btnBuscar" CssClass="btn-buscar" OnClick="btnBuscar_Click" runat="server" Text="Buscar"/>
            </div>
        </div>  
    <script type="text/javascript">
        function close_msn() {
            document.getElementById('msn').innerHTML = "";
            document.getElementById('msn').setAttribute("class", "invisible");
        }
    </script>
</asp:Content>
