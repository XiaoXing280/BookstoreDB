<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BooksInfoPage.aspx.cs" Inherits="LossionBook.BooksInfoPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div id="mainDiv">
        <div style="padding: 10px">
            <a href="CategoryPage.aspx">全部</a>
            >> 
            <a href="CategoryPage.aspx?BLID=<%=BLID %>">
                <asp:HiddenField runat="server" ID="Hid_BLID" />
                <asp:Label ID="lblBLName" runat="server" />
            </a>
            >>
            <asp:Label ID="lblBSName" runat="server" />
        </div>
        <div style="border: 1px solid #DEDFDE; padding: 20px; width: 700px">
            <asp:Repeater runat="server" ID="Rep_Book" OnItemCommand="Rep_Book_ItemCommand">
                <ItemTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td rowspan="6" style="width: 140px">
                                <img src="/BookImages/<%# Eval("ISBN") %>.jpg" />
                            </td>
                            <td><%# Eval("BookTitle") %></td>
                        </tr>
                        <tr>
                            <td>作者：<%# Eval("BookAuthor") %></td>
                        </tr>
                        <tr>
                            <td>出版社：<%# Eval("BookPublish") %></td>
                        </tr>
                        <tr>
                            <td>ISBN：<%# Eval("ISBN") %>&nbsp;&nbsp;书籍字数：<%# Eval("BookCount") %></td>
                        </tr>
                        <tr>
                            <td>已销售数量：<%# Eval("BookSale") %>&nbsp;&nbsp;库存数量：<%# Eval("BookDeport") %>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <font style="text-decoration: line-through">￥<%# Eval("BookPrice") %></font>&nbsp;&nbsp;
				            <font color="#FF7126" style="font-weight: bold">￥<%# Eval("BookMoney") %></font>&nbsp;&nbsp;
                            <asp:ImageButton runat="server" src="/Content/Images/goumaismall.jpg" Style="cursor: pointer; margin-bottom: -6px;" CommandName="Buy" CommandArgument='<%# Eval("BookID") %>' />
                            </td>
                        </tr>
                    </table>
                    <p></p>
                    <strong>编辑推荐</strong>
                    <hr style="width: 100%" />
                    <%# Eval("BookComm") %>
                    <p></p>
                    <strong>内容简介</strong>
                    <hr style="width: 100%" />
                    <%# Eval("BookDesc") %>
                    <p></p>
                    <strong>作者介绍</strong>
                    <hr style="width: 100%" />
                    <%# Eval("BookAuthorDesc") %>
                    <p></p>
                    <strong>目录摘要</strong>
                    <hr style="width: 100%" />
                    <%# Eval("BookContent") %>
                    <p></p>
                </ItemTemplate>
            </asp:Repeater>
            <strong>书籍评价</strong>
            <asp:Repeater runat="server" ID="Rep_BookAppraise">
                <ItemTemplate>
                    <hr style="width: 100%" />
                    <table style="width: 98%">
                        <tr>
                            <td style="width: 200px; vertical-align: top; padding: 10px">
                                <p>会员：<%# Eval("UserNick") %></p>
                                <p><%# Eval("BADate") %></p>
                                <p><%# Eval("BAPoint") %>分</p>
                            </td>
                            <td style="vertical-align: top; padding: 10px"><%# Eval("BADesc") %>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr style="width: 100%" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!--中部结束-->
</asp:Content>
