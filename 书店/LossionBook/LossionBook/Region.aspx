<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Region.aspx.cs" Inherits="LossionBook.Region1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <div style="border: 1px solid #CCCCCC; height: 300px; padding: 30px 100px">
            <table>
                <tr>
                    <td colspan="2">
                        <img src="../Content/images/regisTitle.png" />
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">用户名</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtname" runat="server" CssClass="login_input login_password"></asp:TextBox><font color="red">(必填)</font>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">email</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtemail" runat="server" CssClass="login_input login_password"></asp:TextBox><font color="red">(必填)</font>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">密码</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtpwd" runat="server" CssClass="login_input login_password"></asp:TextBox><font color="red">(必填)</font>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">密码确认</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtpwd1" runat="server" CssClass="login_input login_password"></asp:TextBox><font color="red">(必填)</font>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">性别</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:RadioButtonList ID="rbtnSex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table">
                            <asp:ListItem Selected="True">男</asp:ListItem>
                            <asp:ListItem>女</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr style="height: 30px">
                    <td style="text-align: right">所属姓名</td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:TextBox ID="txtUnick" runat="server" CssClass="login_input login_password"></asp:TextBox><font color="red">(必填)</font>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: right"></td>
                    <td style="text-align: left; padding-left: 10px">
                        <asp:Button ID="btnZC" runat="server" Text="注册" CssClass="btn btn-block btn-login btn-center" Style="border-width: 0px; width: 150px" OnClick="btnZC_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <!--中部结束-->
</asp:Content>
