<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="MainSite.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" media="screen">
</head>
<body>
    <!-- JQuery -->
    <script type="text/javascript" src="Scripts/jquery-1.8.2.js"></script>
    <!-- Bootstrap -->
    <script type="text/javascript" src="Scripts/bootstrap.min.js"></script>
    <form id="form1" runat="server">
    <div class="modal-backdrop">
        <table style="width: 100%; height: 100%">
            <tr>
                <td colspan="2" rowspan="3">
                </td>
                <td>
                </td>
                <td rowspan="3">
                </td>
            </tr>
            <tr>
                <td style="width: 40%; height: 20%">
                    <div class="hero-unit" style="height: 100%">
                        <img src="../Image/ChipAndDale.gif" style="float: right;" alt="Ошибка будет рассмотрена в ближайшее время"/>
                        <h4>
                            Произошла ошибка. Приносим свои извинения.</h4>
                        <p>
                            <asp:Label ID="labelErrorCode" runat="server" Text=""></asp:Label></p>
                        <p>
                            <asp:Label ID="labelErrorMessage" runat="server" Text=""></asp:Label></p>
                        <a href="../Shop.aspx">
                            <div class="btn">
                                <i class="icon-shopping-cart"></i>Перейти в магазин
                            </div>
                        </a>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
