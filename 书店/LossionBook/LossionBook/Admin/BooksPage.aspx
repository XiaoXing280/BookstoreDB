<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksPage.aspx.cs" Inherits="LossionBook.Admin.BooksPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书籍管理</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
    <script type="text/javascript">
        function showAdd() {
            layer.open({
                type: 2,
                title: "添加书籍信息",
                content: ["BooksPageEdit.aspx", "no"],
                area: ["850px", "100%"],
                shadeClose: true
            })
        }
        function showEdit(BookID) {
            layer.open({
                type: 2,
                title: "编辑书籍信息",
                content: ["BooksPageEdit.aspx?BookID=" + BookID, "no"],
                area: ["850px", "100%"],
                shadeClose: true

            })
        }
    </script>
</head>
<body style="margin: 10px">
    <form runat="server" id="form1">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍管理</strong></div>
        <table style="width: 700px; margin: 10px 0px; padding: 5px 2px">
            <tr>
                <td align="right" nowrap="nowrap">书籍名称：</td>
                <td>
                    <asp:TextBox ID="txtBookTitle" runat="server" CssClass="span2"></asp:TextBox>
                </td>
                <td align="right" nowrap="nowrap">大类别：</td>
                <td>
                    <asp:DropDownList ID="drpBLName" runat="server" CssClass="span2" Style="height: 25px" AutoPostBack="True" OnSelectedIndexChanged="drpBLName_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td align="right" nowrap="nowrap">小类别：</td>
                <td>
                    <asp:DropDownList ID="drpBSName" runat="server" CssClass="span2" Style="height: 25px"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td align="right" nowrap="nowrap">出版社：</td>
                <td>
                    <asp:TextBox ID="txtBookPublish" runat="server" CssClass="span2"></asp:TextBox>
                </td>
                <td align="right" nowrap="nowrap">是否秒杀：</td>
                <td>
                    <asp:DropDownList ID="drpBookIsBuy" runat="server" CssClass="span2" Style="height: 25px"></asp:DropDownList>
                </td>
                <td align="right" nowrap="nowrap">是否热门：</td>
                <td>
                    <asp:DropDownList ID="drpBookIsHot" runat="server" CssClass="span2" Style="height: 25px"></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-info" OnClick="btnCX_Click" />
                </td>
            </tr>
        </table>
        <input type="button" value="新增书籍" class="btn btn-info" onclick="showAdd()" />
        <p />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Style="width: 90%" CssClass="table table-bordered table-striped table-hover text-center" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="BookID" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="BookTitle" HeaderText="书籍名" />
                <asp:BoundField DataField="BLName" HeaderText="大类别" />
                <asp:BoundField DataField="BSName" HeaderText="小类别" />
                <asp:BoundField DataField="BookPublish" HeaderText="出版社" />
                <asp:BoundField DataField="BookPrice" HeaderText="标价" />
                <asp:BoundField DataField="BookMoney" HeaderText="售价" />
                <asp:BoundField DataField="BookSale" HeaderText="销售数量" />
                <asp:BoundField DataField="BookDeport" HeaderText="库存数" />
                <asp:BoundField DataField="BookIsBuy" HeaderText="是否秒杀" />
                <asp:BoundField DataField="BookIsHot" HeaderText="是否热门" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a class="btn btn-warning" href="javascript:showEdit(<%# Eval("BookID") %>)">编辑</a>
                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" CommandName="Delete" runat="server" OnClientClick="javascript:return confirm('确定要删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div style="text-align: left; width: 90%">
            <asp:Button ID="btnSY" runat="server" Text="首页" CssClass="btn btn-info" OnClick="btnSY_Click" />
            <asp:Button ID="btnON" runat="server" Text="上一页" CssClass="btn btn-info" OnClick="btnON_Click" />
            <asp:Button ID="btnDOWN" runat="server" Text="下一页" CssClass="btn btn-info" OnClick="btnDOWN_Click" />
            <asp:Button ID="btnWY" runat="server" Text="尾页" CssClass="btn btn-info" OnClick="btnWY_Click" />
            &nbsp;<asp:Button ID="Button2" runat="server" Text="跳转到:" CssClass="btn btn-info" OnClick="Button2_Click" />
            &nbsp;<asp:TextBox ID="txtindex" TextMode="Number" runat="server" Text="1" Width="50px"></asp:TextBox>
            &nbsp;当前页/总页数： 
        <asp:Label ID="labCurrent" runat="server" Text="0"></asp:Label>/
        <asp:Label ID="labCount" runat="server" Text="0"></asp:Label>
        </div>
    </form>
</body>
</html>
