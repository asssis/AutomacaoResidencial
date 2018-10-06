<%@ Page Title="" Language="C#" MasterPageFile="~/Mpage/MPTecnico.Master" AutoEventWireup="true" CodeBehind="WFBuscarComando.aspx.cs" Inherits="HomeControl.Forms.Tecnico.WFBuscarComando" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Css/ControlesPersonalizados.css" rel="stylesheet" />
    <style>
        body {
            background: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="divPreVisualizacao" class="invisible" enableviewstate="true" runat="server">
            <h2>Comando</h2>
            <div class="pre-visualizacao">
                <div class="controle-um-inteiro">
                    <div class="tela-controle" id="divVisualizacaoControle" runat="server">
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
