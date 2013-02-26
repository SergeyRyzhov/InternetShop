<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageItemsWizard.ascx.cs"
    Inherits="MainSite.UserControls.ManageItemsWizard" %>
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
<asp:Table ID="Table1" runat="server" class="table table-striped table-condense"
    Width="100%">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell>
            <asp:Label ID="label1" runat="server" Text="№"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label2" runat="server" Text="Название"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label3" runat="server" Text="Цена"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label4" runat="server" Text="Количество"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label5" runat="server" Text="Стоимость"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label6" runat="server" Text="Управление"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
