<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManageUsersWizard.ascx.cs"
    Inherits="MainSite.UserControls.ManageUsersWizard" %>
<asp:Table ID="Table1" runat="server" class="table table-striped table-condense"
    Width="100%">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell>
            <asp:Label ID="label2" runat="server" Text="ID"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label3" runat="server" Text="Имя"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label4" runat="server" Text="Email"></asp:Label>
        </asp:TableHeaderCell>
        <asp:TableHeaderCell>
            <asp:Label ID="label1" runat="server" Text="Управление"></asp:Label>
        </asp:TableHeaderCell>
    </asp:TableHeaderRow>
</asp:Table>
