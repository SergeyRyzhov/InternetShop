<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="ShopCard.aspx.cs" Inherits="MainSite.ShopCard" %>

<%@ Register Src="~/UserControls/ShoppingCard.ascx" TagName="ShoppingCard" TagPrefix="ShoppingCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div>
        <ShoppingCard:ShoppingCard runat="server" />
    </div>
    <p>
        <a href="../Purchase/OrderList.aspx" class="btn"><i class="icon-briefcase"></i>Составить
            заказ</a>
    </p>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
    <div class="well">
        <h4>
            Меню магазина</h4>
        <p>
            <a href="../Shop.aspx" class="btn"><i class="icon-shopping-cart"></i>Перейти в магазин
            </a>
        </p>
    </div>
</asp:Content>
