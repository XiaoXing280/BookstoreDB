<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryPageADD.aspx.cs" Inherits="LossionBook.Admin.BLCategoryPageADD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>大类别添加</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
</head>
<body style="margin:10px">
    <form runat="server">
    <table class="table table-bordered" style="width:95%">
        <tr>
            <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">大类别名称：</td>
            <td>
                <asp:TextBox ID="txtBLName" Cssclass="span1" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align:center">
        <asp:Button ID="btnQD" runat="server" Text="确定" Cssclass="btn btn-info" OnClick="btnQD_Click"/>
        <asp:Button ID="btnQX" runat="server" Text="取消" Cssclass="btn btn-info" OnClick="btnQX_Click"/>
    </div>
    </form>
</body>
</html>
