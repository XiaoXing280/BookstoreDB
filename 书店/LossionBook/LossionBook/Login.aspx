<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LossionBook.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Content/CSS/bootstrap.css"></script>
    <style>
        #p1 {
            background-color: lightskyblue;
            border-radius: 2px 2px 2px 2px;
            color: white;
            font-size: 18px;
            font-weight: bold;
            width: 300px;
            height: 30px;
            line-height: 30px;
        }

        #p2 {
            background-color: lightskyblue;
            border-radius: 2px 2px 2px 2px;
            color: white;
            font-size: 18px;
            font-weight: bold;
            width: 500px;
            height: 30px;
            line-height: 30px;
        }

        #btnlogin {
            border-radius: 15px 15px 15px 15px;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <div style="border: 1px solid #CCCCCC; height: 400px">
            <div style="float: left; margin: 10px 10px; width: 330px">
                <table>
                    <tr>
                        <td colspan="2">
                            <p id="p1">&nbsp;> |用户登录</p>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">用户名</td>
                        <td style="padding-left: 5px">
                            <asp:TextBox ID="txtname" runat="server" CssClass="login_input login_password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td style="text-align: right">密码</td>
                        <td style="padding-left: 5px">
                            <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" CssClass="login_input login_password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td></td>
                        <td>
                            <asp:Button ID="btnlogin"  runat="server" Text="登录" CssClass="btn btn-primary btn-login btn-center" Style="border-width: 0px;width: 150px;height: 30px;line-height: 30px;border-radius: 10px 10px 10px 10px;font-size:18px" OnClick="btnlogin_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="float: right; margin: 10px 10px">
                <table>
                    <tr>
                        <td>
                            <p id="p2">&nbsp;> |免费注册</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>如果您不是会员，请注册</strong>
                            <p />
                            <strong class="f4">友情提示：</strong><p />
                            不注册为会员也可在本店购买商品<p />
                            但注册之后您可以：<p />
                            1. 保存您的个人资料<p />
                            2. 收藏您关注的商品<p />
                            3. 享受会员积分制度<p />
                            4. 订阅本店商品信息<p />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="Region.aspx">
                                <img src="../Content/images/regisBtn.png" style="border: 0px" />
                            </a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <!--中部结束-->
</asp:Content>
