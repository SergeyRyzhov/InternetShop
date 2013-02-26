<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemViewMini.ascx.cs"
    Inherits="MainSite.UserControls.ItemViewMini" %>
<style type="text/css">
    .left-column
    {
        width: 60%;
    }
    .right-column
    {
        width: 40%;
    }
</style>
<div class="hero-unit">
    <asp:Panel ID="Panel1" runat="server">
        <table class="table" style="width:100%">
            <thead>
                <tr>
                    <td class="left-column">
                        <asp:Label ID="labelName" runat="server" Text="none"></asp:Label>
                        <span class="label label-success">New</span>
                    </td>
                    <td class="right-column">
                        <!--i class="icon-qrcode"></i><small>no image</small-->
                        <asp:Image ID="ImagePreview" runat="server" Width="64" Height="64" />
                    </td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td rowspan="3">
                        Описание<br />
                        <p id="labelDescription" runat="server">
                        </p>
                    </td>
                    <td>
                        Есть на складе<br />
                        <asp:Label ID="labelCount" runat="server" Text="Label"></asp:Label>
                        &nbsp;шт.
                    </td>
                </tr>
                <tr>
                    <td>
                        Цена<br />
                        <asp:Label ID="labelPrice" runat="server" Text="100"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                        <asp:LinkButton ID="addToCard" runat="server" OnClick="addToCard_Click" Visible="False">Добавить в корзину</asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>
        <div class="row">
            <div class="span2">
                <asp:TextBox class="text-success span2" ID="TextBoxCount" runat="server" Text="1"></asp:TextBox>
            </div>
            <div class="span5">
                <asp:Button class="btn btn-success" ID="btnBuy" runat="server" Text="Добавить в корзину"
                    OnClick="addToCard_Click" ValidationGroup="addGroup" />
                <a href="../Users/ShopCard.aspx">
                    <div class="btn">
                        <i class="icon-shopping-cart"></i>Открыть корзину
                    </div>
                </a>
            </div>
        </div>
        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextCount" runat="server"
            ErrorMessage="Укажите количество" ValidationGroup="addGroup" ControlToValidate="TextBoxCount"
            SetFocusOnError="True" CssClass="alert alert-error" EnableViewState="True" ValidationExpression="^-?[1-9]?[0-9]*$">Укажите число
        </asp:RegularExpressionValidator>

        <asp:HiddenField ID="fieldID" runat="server" />
    </asp:Panel>
</div>
