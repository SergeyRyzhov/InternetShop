﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="ControlPanel.aspx.cs" Inherits="MainSite.ControlPanel" %>

<%@ Register Src="~/UserControls/AddProductWizard.ascx" TagName="AddProductWizard"
    TagPrefix="AddProductWizard" %>
<%@ Register Src="~/UserControls/ManageItemsWizard.ascx" TagName="ManageItemsWizard"
    TagPrefix="ManageItemsWizard" %>
<%@ Register Src="~/UserControls/ManageUsersWizard.ascx" TagName="ManageUsersWizard"
    TagPrefix="ManageUsersWizard" %>
<%@ Register Src="~/UserControls/BuyHistoryWizard.ascx" TagName="BuyHistoryWizard"
    TagPrefix="BuyHistoryWizard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <h3>
        Панель управления администратора</h3>
    <h4>
        Добавление или изменение тавара</h4>
    <AddProductWizard:AddProductWizard runat="server"></AddProductWizard:AddProductWizard>
    <h4>
        Удаление тавара</h4>
    <ManageItemsWizard:ManageItemsWizard ID="AddProductWizard1" runat="server"></ManageItemsWizard:ManageItemsWizard>
    <h4>
        Добавление пользователя</h4>
    <div class="hero-unit">
        <center>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8"
                BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em"
                OnCreatedUser="CreateUserWizard1_CreatedUser">
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    </asp:CreateUserWizardStep>
                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                    </asp:CompleteWizardStep>                </WizardSteps>
                <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em"
                    ForeColor="White" HorizontalAlign="Center" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
                <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
                <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
                <StepStyle BorderWidth="0px" />
            </asp:CreateUserWizard>
        </center>
    </div>
    <h4>
        Удаление пользователя</h4>
    <ManageUsersWizard:ManageUsersWizard runat="server"></ManageUsersWizard:ManageUsersWizard>
    <h4>
        История покупок</h4>
    <BuyHistoryWizard:BuyHistoryWizard runat="server"></BuyHistoryWizard:BuyHistoryWizard>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightmenu" runat="server">
</asp:Content>
