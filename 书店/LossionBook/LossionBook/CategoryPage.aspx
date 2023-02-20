<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="CategoryPage.aspx.cs" Inherits="LossionBook.CategoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="mainDiv">
        <div style="padding: 10px">
            <a href="CategoryPage.aspx">全部</a>
            >> 
            <a href="CategoryPage.aspx?BLID=<%=BLID %>">
                <asp:Label ID="lblBLName" runat="server" />
            </a>
            >>
            <asp:Label ID="lblBSName" runat="server" />
        </div>
        <asp:Repeater runat="server" ID="rep_Table">
            <ItemTemplate>
                <table style="width: 100%">
                    <tr>
                        <td rowspan="5" style="width: 140px">
                            <a href="BooksInfoPage.aspx?BookID=<%# Eval("BookID") %>">
                                <img style="width: 120px; height: 160px" src="/BookImages/<%# Eval("ISBN") %>.jpg" />
                            </a>
                        </td>
                        <td><a href="BooksInfoPage.aspx?BookID=<%# Eval("BookID") %>"><%#Eval("BookTitle") %></a></td>
                    </tr>
                    <tr>
                        <td>作者：<%#Eval("BookAuthor") %></td>
                    </tr>
                    <tr>
                        <td>出版社：<%#Eval("BookPublish") %></td>
                    </tr>
                    <tr>
                        <td>已销售数量：<%#Eval("BookSale") %>&nbsp;&nbsp;库存数量：<%#Eval("BookDeport") %>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <font style="text-decoration: line-through">￥<%#Eval("BookPrice") %></font>&nbsp;&nbsp;
                        <font color="#FF7126" style="font-weight: bold">￥<%#Eval("BookMoney") %></font>&nbsp;&nbsp;
                            <asp:ImageButton runat="server" src="/Content/Images/goumaismall.jpg" Style="cursor: pointer; margin-bottom: -6px" CommandName="Buy" CommandArgument='<%# Eval("BookID") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><%#Eval("BookDesc") %>
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
            <br />
        </div>
    </div>
</asp:Content>
