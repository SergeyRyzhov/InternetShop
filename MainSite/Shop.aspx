<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="Shop.aspx.cs" Inherits="MainSite.Shop" %>

<%@ Register Src="~/UserControls/ItemViewMini.ascx" TagName="ItemViewMini" TagPrefix="ItemViewMini" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h4>
        Список товаров</h4>
    <asp:Panel ID="Panel1" runat="server" Style="width: 100%">
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
    <div class="well">
        <h4>
            Меню магазина</h4>
        <a href="../Users/ShopCard.aspx">
            <div class="btn">
                <i class="icon-shopping-cart"></i>Открыть корзину
            </div>
        </a>
    </div>
</asp:Content>
