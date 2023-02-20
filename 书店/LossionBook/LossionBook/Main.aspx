<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="LossionBook.Main1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!--中部开始-->
    <div id="mainDiv">
        <div class="redAll" style="float: right; width: 100%">
            <div class="redTitle" style="float: right; width: 725px">秒杀专区</div>
            <asp:Repeater ID="repBuy" runat="server" OnItemCommand="repBuy_ItemCommand">
                <ItemTemplate>
                    <div style="float: left; margin: 5px 5px; overflow: hidden">
                        <div style="width: 135px; text-align: center">
                            <a href="BooksPage.html">
                                <img src='BookImages/<%# Eval("ISBN") %>.jpg' style="border: 1px solid #CDCECE; width: 80px; height: 110px" />
                            </a>
                        </div>
                        <div style="height: 25px; line-height: 15px; text-align: center">
                            <a title='<%# Eval("BookTitle") %>' href="BooksPage.html">
                                <p style="width: 120px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                            </a>
                        </div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font style="text-decoration: line-through">￥<%# Eval("BookMoney") %></font></div>
                        <div style="height: 15px; line-height: 15px; text-align: center">
                            <font color="#FF7126" style="font-weight: bold">￥<%# Eval("BookPrice") %></font></div>
                        <div style="text-align: center">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Content/images/goumaismall.jpg" CommandName="buy" CommandArgument='<%# Eval("BookID") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="clear: both"></div>
        <p></p>
        <div class="redAll" style="float: right; width: 100%">
            <div class="redTitle" style="float: right; width: 725px">热门推荐</div>
            <asp:Repeater ID="repHot" runat="server" OnItemCommand="repHot_ItemCommand">
                <ItemTemplate>
                    <div style="float: left; margin-top: 5px; margin-left: 7px">
                        <div style="width: 130px; text-align: center">
                            <a href="BooksPage.html">
                                <img src='BookImages/<%# Eval("ISBN") %>.jpg' style="border: 1px solid #CDCECE; width: 120px; height: 170px" />
                            </a>
                        </div>
                        <div style="margin: 5px 5px; width: 130px; text-align: center">
                            <a title='<%# Eval("BookTitle") %>' href="BooksPage.html">
                                <p style="width: 120px; overflow: hidden; white-space: nowrap; text-overflow: ellipsis;"><%# Eval("BookTitle") %></p>
                            </a>
                        </div>
                        <div style="margin: 5px 5px; width: 130px; text-align: center">
                            <font color="#999999" style="text-decoration: line-through">￥<%# Eval("BookMoney") %></font>
                        </div>
                        <div style="margin: 5px 5px; width: 130px; text-align: center">
                            <font color="#FF7126" style="font-weight: bold">￥<%# Eval("BookPrice") %></font>
                        </div>
                        <div style="margin: 5px 5px; width: 130px; text-align: center">
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Content/images/goumaismall.jpg" CommandName="buy" CommandArgument='<%# Eval("BookID") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
    <!--中部结束-->

</asp:Content>
