<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="LossionBook.Admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>文电书城后台管理系统</title>
    <%=Styles.Render("~/bundles/UICss") %>
    <%=Scripts.Render("~/bundles/UIJS") %>
    <style type="text/css">
        .active {
            background-color: #38A3D5;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("div a").click(function () {
                $("div a").removeClass("active");
                var url = $(this).attr("url");
                $("#page").attr("src", url + "?" + Math.random());
                $(this).addClass("active");
            });
        });
    </script>
</head>
<body>
<form runat="server">
    <div class="header">
        <div class="logo" style="color: white; font-size: 28px; font-weight: bold; font-family: 'Microsoft YaHei UI'; padding: 20px 20px">万树IT电子书城后台管理系统</div>

        <div class="header-right" style="padding:0px 0px">
            <i class="icon-question-sign icon-white"></i> <a href="#">帮助</a>
            <i class="icon-off icon-white"></i>
			 <a id="modal-973558" href="#" role="button" data-toggle="modal">注销</a>
			 <a id="modal-973558" href="#" role="button" data-toggle="modal">修改密码</a>
        </div>
    </div>
    <!-- 顶部 -->
    <div id="middle">
        <div class="left">
            <div id="my_menu" class="sdmenu">
                <div>
                    <span>基础数据管理</span>
                    <a href="#" url="BLCategoryPage.aspx">书籍大类别管理</a>
                    <a href="#" url="BSCategoryPage.aspx">书籍小类别管理</a>
                    <a href="#" url="BooksPage.aspx">书籍管理</a>
                </div>
                <div>
                    <span>单据管理</span>
                    <a href="#" url="OrderPage.aspx">订单管理</a>
                </div>
            </div>

        </div>
        <div class="Switch"></div>
        <script type="text/javascript">
            $(document).ready(function (e) {
                $(".Switch").click(function () {
                    $(".left").toggle();
                });
            });
        </script>

        <div class="right" id="mainFrame">
            <iframe id="page" name="page" scrolling="auto" frameborder="0" src="Main.aspx" style="width:98%;height:99%"></iframe>
        </div>
    </div>
</form>
</body>
</html>
