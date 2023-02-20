<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BLCategoryPage.aspx.cs" Inherits="LossionBook.Admin.BLCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>书籍大类别管理</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
    <script type="text/javascript">
        function showAdd() {
            layer.open({
                type: 2,
                title: "添加大类别",
                content: ["BLCategoryPageADD.aspx","no"],
                area: ["400px","200px"],
                offset:"100px",
            })
        }
        function showEdit(id) {
            layer.open({
                type: 2,
                title: "编辑大类别",
                content: ["BLCategoryPageEdit.aspx?id=" + id, "no"],
                area: ["400px", "200px"],
                offset: "100px",
            })
        }
    </script>
    <style type="text/css">
        .table-hover {}
    </style>
</head>
<body style="margin: 10px">
    <form id="form1" runat="server">
    <div class="title_right">
        <span class="pull-right margin-bottom-5"></span><strong>书籍大类别管理</strong>
    </div>
    <input type="button" value="新增大类别" class="btn btn-info" onclick="showAdd()" />
    <p></p>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped table-hover text-center" AutoGenerateColumns="False" DataKeyNames="BLID" Width="390px" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="大类型类别名称" DataField="BLName" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                        <a class="btn btn-warning" href="javascript:showEdit(<%# Eval("BLID") %>)">编辑</a>
                        <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('确定要删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
    
</body>
</html>
