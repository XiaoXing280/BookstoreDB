<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksPageEdit.aspx.cs" Inherits="LossionBook.Admin.BooksPageEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
</head>
<body style="margin: 10px">
    <form id="form1" runat="server">
        <div class="title_right">
            <span class="pull-right margin-bottom-5"></span><strong>书籍信息</strong>
        </div>
        <div style="height: 800px; overflow: auto;">
            <table class="table table-bordered" style="width: 98%">
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">书籍名称：</td>
                    <td>
                        <asp:TextBox ID="txtBookTitle" runat="server" CssClass="span4"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">作者：</td>
                    <td>
                        <asp:TextBox ID="txtBookAuthor" runat="server" CssClass="span4"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">出版社：</td>
                    <td>
                        <asp:TextBox ID="txtBookPublish" runat="server" CssClass="span2"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">ISBN：</td>
                    <td>
                         <asp:Image ID="imgISBN" runat="server" Height="50px" Width="85px" />
                        <asp:FileUpload  ID="ulPhoto" runat="server" CssClass="span2" accept=".jpg"/>
                        <%--<asp:FileUpload ID="ulPhoto" runat="server" />&nbsp;
                        <asp:TextBox ID="txtISBN" runat="server" CssClass="span2"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">大类别：</td>
                    <td>
                        <asp:DropDownList ID="drpBLName" runat="server" CssClass="span2" Style="height: 25px" AutoPostBack="True" OnSelectedIndexChanged="drpBLName_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">小类别：</td>
                    <td>
                        <asp:DropDownList ID="drpBSName" runat="server" CssClass="span2" Style="height: 25px"></asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">标价：</td>
                    <td>
                        <asp:TextBox ID="txtBookPrice" TextMode="Number" Text="0" runat="server" CssClass="span2"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">售价：</td>
                    <td>
                        <asp:TextBox ID="txtBookMoney" TextMode="Number" Text="0" runat="server" CssClass="span2"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 40px">
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">字数：</td>
                    <td>
                        <asp:TextBox ID="txtBookCount" TextMode="Number" Text="0" runat="server" CssClass="span2"></asp:TextBox>
                    </td>
                    <td align="right" nowrap="nowrap" bgcolor="#f1f1f1">初始库存：</td>
                    <td>
                        <asp:TextBox ID="txtBookDeport" TextMode="Number" Text="0" runat="server" CssClass="span2"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">书籍介绍：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea id="BookDesc" runat="server" style="width: 95%; height: 60px"></textarea>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">作者介绍：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea id="BookAuthorDesc" runat="server" style="width: 95%; height: 60px"></textarea>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">推荐内容：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea id="BookComm" runat="server" style="width: 95%; height: 60px"></textarea>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td nowrap="nowrap" bgcolor="#f1f1f1">内容简介：</td>
                    <td colspan="3" style="padding: 5px">
                        <textarea id="BookContent" runat="server" name="editor01" style="width: 95%; height: 60px"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnQD" runat="server" Text="确定" CssClass="btn btn-info" OnClick="btnQD_Click" />
                        <asp:Button ID="btnQX" runat="server" Text="取消" CssClass="btn btn-info" OnClick="btnQX_Click" />
                    </td>
                </tr>
            </table>
            <script type="text/javascript">CKEDITOR.replace('editor01');</script>
            <div style="height: 100px"></div>
        </div>

    </form>


</body>
</html>
