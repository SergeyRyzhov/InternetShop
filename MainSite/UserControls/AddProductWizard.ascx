<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProductWizard.ascx.cs"
    Inherits="MainSite.UserControls.AddProductWizard" %>
<div class="hero-unit">
    <asp:Panel ID="Panel1" runat="server">
        <table>
            <tr>
                <td class="style1" colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Название"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style1">
                    <asp:TextBox ID="textBoxName" runat="server" Width="600px" ValidationGroup="addGroup"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextName" runat="server" ErrorMessage="Необходимо ввести название"
                        ValidationGroup="addGroup" ControlToValidate="textBoxName" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="style1">
                    <asp:Label ID="Label2" runat="server" Text="Описание"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                    <asp:TextBox ID="textBoxDescription" runat="server" Height="168px" TextMode="MultiLine"
                        Width="600px">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatoTextDescription" runat="server"
                        ErrorMessage="Необходимо ввести описание" ValidationGroup="addGroup" ControlToValidate="textBoxDescription"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label3" runat="server" Text="Цена"></asp:Label>
                </td>
                <td class="style2">
                    <asp:Label ID="Label4" runat="server" Text="Количество"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:TextBox ID="textBoxPrice" runat="server">
                    </asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidatorTextPrice" runat="server"
                        ErrorMessage="Укажите цену" ValidationGroup="addGroup" ControlToValidate="textBoxPrice"
                        SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
                <td class="style2">
                    <asp:TextBox ID="textBoxCount" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextCount" runat="server" ErrorMessage="Укажите количество"
                        ValidationGroup="addGroup" ControlToValidate="textBoxCount" SetFocusOnError="True">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="imageLoader" runat="server" />
                    <asp:Button class="btn" ID="ButtonUpload" runat="server" Text="Добавить" CommandName="UploadPicture" />
                </td>
                <td>
                    <asp:Image ID="imageMiniView" runat="server" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummaryAddGroup" runat="server" ValidationGroup="addGroup"
            HeaderText="Обнаружены следующие ошибки:" CssClass="alert-error alert" Display="Dynamic"
            BorderStyle="Groove" ForeColor="" />
        <asp:Button class="btn btn-warning" ID="buttonClear" runat="server" Text="Очистить"
            CommandName="ClearForm" />
        <asp:Button class="btn btn-success" ID="buttonAdd" runat="server" Text="Добавить/Изменить"
            ValidationGroup="addGroup" CommandName="AddProduct" />
    </asp:Panel>
</div>
