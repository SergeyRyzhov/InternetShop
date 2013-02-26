<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="OrderList.aspx.cs" Inherits="MainSite.Purchase.OrderList" %>

<%@ Register Src="~/UserControls/OrderList.ascx" TagName="OrderList" TagPrefix="OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h4>
        Ваш заказ</h4>
    <OrderList:OrderList runat="server" />
    <div class="alert alert-info">
        Тут должна быть форма оформления места доставки
    </div>
    <div>
        <i class="icon-ok"></i>
        <asp:Button ID="ButtonMakeOrder" runat="server" Text="Оплатить" OnClick="ButtonMakeOrder_Click"
            class="btn" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
