<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPCliente.Master" AutoEventWireup="true" CodeBehind="WFHistorico.aspx.cs" Inherits="HomeControl.Forms.Cliente.WFHistorico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style>
              .item-historico {
            float:left;             
            background:#2b9dd1;
            border: 0px;
            color: #fff;
            font-size:30px;
            border-radius: 10px;
            margin: 2px;
            width:calc(100% - 24px) ;
            padding:10px;
            margin-top:10px;
        }
                  .item-historico > p.historico {
                margin-top:0px;
                background:#777;
            }
            .item-historico > p {
                margin-bottom:0px;
                margin-top:10px;                    
                background:#eee;
                color:#000;
                padding:10px;
                border-radius:10px;
            }
     .data-historico {
         float:left;
         clear:both;
         margin-left:0px;
         background:#2b9dd1;
         font-size:30px;
         border-radius:10px;
         width:200px;
         text-align:center;
         color:#fff;
     }
          </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="tela-controle" id="divVisualizacaoHistorico" runat="server">
         
      </div>
        <div class="tela-simples">
            <a class="a-toch-um-meio ativo-azul" href="WFControle.aspx">VOLTAR</a>
            <a class="a-toch-um-meio ativo-azul" href="WFUnidade.aspx">HOME</a>
        </div>
</asp:Content>
