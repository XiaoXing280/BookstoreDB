<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetailPage.aspx.cs" Inherits="LossionBook.Admin.OrderDetailPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单详细信息</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
</head>
<body style="margin: 10px">
    <form id="form1" runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单详细信息</strong></div>
        <div style="height: 600px; overflow: auto;">
            <table class="table table-bordered" style="width: 98%">
                <tr style="height: 30px">
                    <td colspan="4">
                        <strong>订单信息</strong>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单编号：</td>
                    <td>
                        <asp:Label ID="lblOrderNum" runat="server"></asp:Label></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单时间：</td>
                    <td>
                        <asp:Label ID="lblOrderDate" runat="server"></asp:Label></td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单总金额：</td>
                    <td>
                        <asp:Label ID="lblOrderMoney" runat="server"></asp:Label></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">订单状态：</td>
                    <td>
                        <asp:Label ID="lblOrderState" runat="server"></asp:Label></td>
                </tr>
                <tr style="height: 30px">
                    <td colspan="4">
                        <strong>购物人信息</strong>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">登录账号：</td>
                    <td>
                        <asp:Label ID="lblUserName" runat="server"></asp:Label></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">收货人：</td>
                    <td>
                        <asp:Label ID="lblUserNick" runat="server"></asp:Label></td>
                </tr>
                <tr style="height: 30px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">联系电话：</td>
                    <td>
                        <asp:Label ID="lblAMTel" runat="server"></asp:Label></td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">收货地址：</td>
                    <td>
                        <asp:Label ID="lblAMAddress" runat="server"></asp:Label></td>
                </tr>
            </table>
            <p></p>
            <strong>订单详细信息</strong>
            <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-hover" Style="width: 98%" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="书籍名" />
                    <asp:BoundField DataField="ODPrice" HeaderText="单价" />
                    <asp:BoundField DataField="ODCount" HeaderText="数量" />
                    <asp:BoundField DataField="ODMoney" HeaderText="总金额" />
                </Columns>
            </asp:GridView>
            <div>
                <asp:Button ID="btnQX" runat="server" Text="返回" CssClass="btn btn-info" OnClick="btnQX_Click" />
            </div>
            <div style="height: 80px"></div>
        </div>
    </form>
</body>
</html>
