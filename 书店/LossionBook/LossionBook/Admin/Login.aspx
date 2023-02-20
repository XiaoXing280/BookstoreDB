<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LossionBook.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文电书城后台管理系统</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
    <style type="text/css">
        body {
            background: #0066A8 url(../Content/Images/login_bg.png) no-repeat center 0px;
        }

        .tit {
            margin: auto;
            margin-top: 170px;
            text-align: center;
            width: 350px;
            padding-bottom: 20px;
        }

        .login-wrap {
            width: 220px;
            padding: 30px 50px 0 330px;
            height: 220px;
            background: #fff url(../Content/Images/20150212154319.jpg) no-repeat 30px 42px;
            margin: auto;
            overflow: hidden;
        }

        .login_input {
            display: block;
            width: 210px;
        }

        .login_user {
            background: url(../Content/Images/input_icon_1.png) no-repeat 200px center;
            font-family: "Lucida Sans Unicode", "Lucida Grande", sans-serif;
        }

        .login_password {
            background: url(../Content/Images/input_icon_2.png) no-repeat 200px center;
            font-family: "Courier New", Courier, monospace;
        }

        .btn-login {
            background: #40454B;
            box-shadow: none;
            text-shadow: none;
            color: #fff;
            border: none;
            height: 35px;
            line-height: 26px;
            font-size: 14px;
            font-family: "microsoft yahei";
        }

            .btn-login:hover {
                background: #333;
                color: #fff;
            }

        .copyright {
            margin: auto;
            margin-top: 10px;
            text-align: center;
            width: 370px;
            color: #CCC;
        }

        @media (max-height: 700px) {
            .tit {
                margin: auto;
                margin-top: 100px;
            }
        }

        @media (max-height: 500px) {
            .tit {
                margin: auto;
                margin-top: 50px;
            }
        }
    </style>

    <script>
        function showCode(my) {
            my.src = "ValidateCode.aspx?data=" + Math.random();
        }
    </script>
</head>

<body>
    <form runat="server">
        <div class="tit" style="color: white; font-size: 28px; font-weight: bold; font-family: 'Microsoft YaHei UI'">万树IT电子书城管理系统</div>
        <div class="login-wrap">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="23" valign="bottom">用户名：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="login_input login_user"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="23" valign="bottom">密  码：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtPassWord" TextMode="Password" runat="server" CssClass="login_input login_password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="23" valign="bottom">验证码：</td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtvalicode" runat="server" CssClass="input-small"></asp:TextBox>
                        <img src="ValidateCode.aspx" style="cursor: pointer;" onclick="showCode(this)" />
                    </td>
                </tr>
                <tr>
                    <td height="40" valign="bottom">
                        <asp:Button ID="btnlogin" runat="server" Text="登录" CssClass="btn btn-block btn-login" OnClick="btnlogin_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
