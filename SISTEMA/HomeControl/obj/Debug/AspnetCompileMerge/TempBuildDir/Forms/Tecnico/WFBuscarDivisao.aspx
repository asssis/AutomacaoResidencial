<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFBuscarDivisao.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFBuscarDivisao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="inicio bloco-inteiro">
            <h2>Divisão</h2>               
            <asp:DropDownList ID="ddlPesquisa" CssClass="ddl-pesquisa" runat="server">
                <asp:ListItem>Geral</asp:ListItem>
            </asp:DropDownList>
            <div class="controle-um-meio controle-meio">
                <asp:TextBox ID="txtPesquisa" CssClass="txt-pesquisa-um-meio" runat="server"></asp:TextBox>
                <asp:Button ID="btnPesquisa" CssClass="btn-pesquisa" OnClick="btnPesquisa_Click" runat="server" Text="Pesquisar" />
            </div>
               <asp:GridView ID="gvPesquisaDivisao" CssClass="grid-justificado" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPesquisaDivisao_SelectedIndexChanged" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Matricula"/>
                    <asp:BoundField DataField="ObjUnidade.Id" HeaderText="Unidade" />
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />                    
                    <asp:CommandField SelectText="Selecionar" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>
</asp:Content>
