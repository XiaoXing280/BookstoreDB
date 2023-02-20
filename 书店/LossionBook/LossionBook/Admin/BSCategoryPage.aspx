<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BSCategoryPage.aspx.cs" Inherits="LossionBook.Admin.BSCategoryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>小类别管理</title>
    <link href="~/Content/CSS/Css1.css" rel="stylesheet" />
     <link href="~/Content/CSS/bootstrap.css" rel="stylesheet" />
    <%=Scripts.Render("~/bundles/UIJS") %>
    <style>
        html, body { padding: 0px!important; padding: 100px 0px; width: 100%; height: 100%;overflow-x:hidden; }
    </style>
    <script type="text/javascript">
        function showAdd() {
            layer.open({
                type: 2,
                title: "添加小类别",
                content: ["BSCategoryPageADD.aspx", "no"],
                area: ["400px", "200px"],
                offset: "100px",
            })
        }
        function showEdit(id) {
            layer.open({
                type: 2,
                title: "编辑小类别",
                content: ["BSCategoryPageEdit.aspx?id=" + id, "no"],
                area: ["400px", "200px"],
                offset: "100px",
            })
        }
    </script>
</head>
<body style="margin:10px">
    <form id="form1" runat="server">
    <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>书籍小类别管理</strong></div>
    <table style="margin:10px 0px;padding:5px 2px">
        <tr>
            <td align="right" nowrap="nowrap">所属大类别：</td>
            <td>
                <asp:DropDownList ID="DropDownList1"  class="span2" runat="server"></asp:DropDownList>
            </td>
            <td>
                &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="查询" Cssclass="btn btn-info" OnClick="Button1_Click"/>
           </td>
        </tr>
    </table>
    <input type="button" value="新增小类别" class="btn btn-info" onclick="showAdd()" />
    <p />
        <asp:GridView ID="GridView1" CssClass="table table-bordered table-striped table-hover text-center" runat="server" AutoGenerateColumns="False" Width="503px" DataKeyNames="BSID" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="BSName" HeaderText="小类别名称" />
                <asp:BoundField DataField="BLName" HeaderText="所属大类别" />
                <asp:TemplateField HeaderText="操作">
                    <ItemTemplate>
                         <a class="btn btn-warning" href="javascript:showEdit(<%# Eval("BSID") %>)">编辑</a>
                        <asp:LinkButton CssClass="btn btn-danger" ID="LinkButton2" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('确定要删除吗？')">删除</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
