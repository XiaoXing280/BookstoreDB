<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="LossionBook.Admin.OrderPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>订单管理</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
    <style>
        .a1:hover {
        text-decoration:none;
        }
    </style>
     <script type="text/javascript">
         function showInfo(OrderID) {
            layer.open({
                type: 2,
                title: "订单详细信息",
                content: ["OrderDetailPage.aspx?OrderID=" + OrderID, "no"],
                area: ["850px", "90%"],
                offset: "5%",
                shadeClose: true
            })
        }
     </script>
</head>
<body style="margin: 10px">
    <form id="form" runat="server">
        <div class="title_right"><span class="pull-right margin-bottom-5"></span><strong>订单管理</strong></div>
        <table style="width: 900px; margin: 10px 0px; padding: 5px 2px" >
            <tr class="text-center">
                <td align="right" nowrap="nowrap">订单编号：</td>
                <td>
                     <asp:TextBox ID="txtOrderNum" runat="server" CssClass="span2"></asp:TextBox>
                </td>
                <td align="right" nowrap="nowrap">客户姓名：</td>
                <td>
                    <asp:TextBox ID="txtUserNick" runat="server" CssClass="span2"></asp:TextBox>
                </td>
                <td align="right" nowrap="nowrap">订单状态：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="span2" style="height: 25px"></asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="Calendar1" TextMode="Date" runat="server" CssClass="laydate-icon span1-1" value="yyyy/mm/日"></asp:TextBox>至
                    <asp:TextBox ID="Calendar2" TextMode="Date" runat="server" CssClass="laydate-icon span1-1" value="yyyy/mm/日"></asp:TextBox>
                </td>
                 <td><asp:Button ID="btnCX" runat="server" Text="查询" CssClass="btn btn-info" OnClick="btnCX_Click" /></td>
            </tr>
        </table>
        <p />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" style="width:90%" Cssclass="table table-bordered table-striped table-hover text-center" DataKeyNames="OrderID" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="订单编号">
                <ItemTemplate>
                     <a class="a1" id="OrderNum" href="javascript:showInfo(<%# Eval("OrderID") %>)"><%#Eval("OrderNum") %></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="UserNick" HeaderText="客户姓名" />
            <asp:BoundField DataField="OrderDate" HeaderText="订单时间" />
            <asp:BoundField DataField="OrderMoney" HeaderText="总金额" />
            <asp:BoundField DataField="OrderState" HeaderText="状态" />
            <asp:TemplateField HeaderText="操作">
                 <ItemTemplate>
                        <asp:LinkButton runat="server" ID="Btn_Edit" Text="操作" CommandName="DoEdit" CommandArgument='<%#Eval("OrderID") %>' />
                    </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        </asp:GridView>

         <div style="text-align: left; width: 90%">
            <asp:Button ID="btnSY" runat="server" Text="首页" CssClass="btn btn-info" />
            <asp:Button ID="btnON" runat="server" Text="上一页" CssClass="btn btn-info" />
            <asp:Button ID="btnDOWN" runat="server" Text="下一页" CssClass="btn btn-info" />
            <asp:Button ID="btnWY" runat="server" Text="尾页" CssClass="btn btn-info" />
            &nbsp;<asp:Button ID="Button2" runat="server" Text="跳转到:" CssClass="btn btn-info" />
            &nbsp;<asp:TextBox ID="txtindex" TextMode="Number" runat="server" Text="1" Width="50px"></asp:TextBox>
            &nbsp;当前页/总页数： 
        <asp:Label ID="labCurrent" runat="server" Text="0"></asp:Label>/
        <asp:Label ID="labCount" runat="server" Text="0"></asp:Label>
        </div>
    </form>
   
</body>
</html>
