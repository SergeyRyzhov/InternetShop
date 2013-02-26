<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ShoppingCard.ascx.cs"
    Inherits="MainSite.UserControls.ShoppingCard" %>
<asp:GridView CssClass="table table-striped table-condense" ID="GridViewShopCard"
    runat="server" GridLines="None" ShowHeaderWhenEmpty="True" DataKeyNames="Name,Price,Count,ID"
    AutoGenerateColumns="False" OnRowCommand="GridViewShopCard_RowCommand" ShowFooter="True"
    OnRowDataBound="GridViewShopCard_RowDataBound">
    <Columns>
        <asp:BoundField HeaderText="№" DataField="Number" />
        <asp:BoundField HeaderText="Название" DataField="Name" />
        <asp:BoundField HeaderText="Цена" DataField="Price" />
        <asp:TemplateField FooterText="Итого">
            <HeaderTemplate>
                Количество
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label runat="server" Text='<%#DataBinder.GetPropertyValue(Container.DataItem, "Count")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField FooterText="0">
            <HeaderTemplate>
                Стоимость
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label runat="server" ID="lblCost" Text='<%#DataBinder.GetPropertyValue(Container.DataItem, "Cost")%>'></asp:Label>
            </ItemTemplate>
            <FooterTemplate>
                <asp:Label runat="server" ID="lblTotalCost"></asp:Label>
            </FooterTemplate>
        </asp:TemplateField>
        <asp:ButtonField CommandName="Delete" Text="Удалить" HeaderText="Управление" ControlStyle-CssClass="btn btn-danger" />
    </Columns>
</asp:GridView>
