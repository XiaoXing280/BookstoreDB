<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryPageEdit.aspx.cs" Inherits="LossionBook.Admin.BSCategoryPageEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>小类别编辑</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
</head>
<body style="margin: 10px">
    <form runat="server">
        <table class="table table-bordered" style="width: 95%">
            <tr>
                <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">小类别名称：</td>
                <td>
                    <asp:TextBox ID="txtBSName" runat="server" class="span2"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">所属大类别：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" class="span2" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <div style="text-align: center">
            <asp:Button ID="btnQD" runat="server" Text="确定" CssClass="btn btn-info" OnClick="btnQD_Click" />
            <asp:Button ID="btnQX" runat="server" Text="取消" CssClass="btn btn-info" OnClick="btnQX_Click" />
        </div>
    </form>

</body>
</html>
