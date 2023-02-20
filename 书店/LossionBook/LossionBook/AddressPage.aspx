<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="AddressPage.aspx.cs" Inherits="LossionBook.AddressPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
        <div>
            <p></p>
            <div style="background-color:#F6F6F6;color:Black;font-weight:bold;font-size:14px;height:30px;line-height:30px;padding:3px 10px">地址管理</div>
            <p></p>
            <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址(必填)：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="txtAdd" runat="server" style="width:471px;"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="Button1" runat="server" Text="新增地址" OnClick="Button1_Click" />&nbsp;&nbsp;
                    </td>
                </tr>
            </table>
            <p></p>
            <strong>地址列表</strong>
            <hr />
            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                       <table class="dataTable" style="width:98%">
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货人姓名(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("AMUser") %>'></asp:TextBox>
                    </td>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">联系电话(必填)：</td>
                    <td style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("AMTel") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px;width:150px">收货地址(必填)：</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:TextBox ID="TextBox3" runat="server" style="width:471px;" Text='<%# Eval("AMAddress") %>'></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;height:30px;line-height:30px;padding:0px 8px">&nbsp;</td>
                    <td colspan="3" style="text-align:left;height:30px;line-height:30px;padding:0px 8px">
                        <asp:Button ID="btnSave" runat="server" Text="保存修改" CommandName="save" CommandArgument='<%# Eval("AMID") %>' />&nbsp;&nbsp;
                        <asp:Button ID="btnDefault" runat="server" Text="保存为默认地址" CommandName="default" CommandArgument='<%# Eval("AMID") %>' />&nbsp;&nbsp;
                       <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="delete" CommandArgument='<%# Eval("AMID") %>' OnClientClick="javascript:return confirm('是否删除')" />
                    </td>
                </tr>
            </table>
            <p></p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    <!--中部结束-->
</asp:Content>
