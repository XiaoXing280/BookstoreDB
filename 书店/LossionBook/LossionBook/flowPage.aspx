<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="flowPage.aspx.cs" Inherits="LossionBook.flowPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--中部开始-->
    <div>
        <div style="background-color: #F6F6F6; color: Black; font-weight: bold; font-size: 14px; height: 30px; line-height: 30px; padding: 3px 10px">购物车 商品列表</div>
        <p></p>
        <div>
            <asp:GridView ID="GridView1" runat="server" CssClass="dataTable" AutoGenerateColumns="False" DataKeyNames="BookID" Width="98%" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" >
                <Columns>
                    <asp:BoundField DataField="BookTitle" HeaderText="商品名称" />
                    <asp:BoundField DataField="BookPrice" HeaderText="售价" />
                    <asp:BoundField DataField="BookMoney" HeaderText="折扣价" />
                    <asp:TemplateField HeaderText="购买数量">
                        <ItemStyle HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Button ID="btnAdd" runat="server" Text="+" CommandName="add" CommandArgument='<%# Container.DataItemIndex%>' />
                            <asp:Label ID="labAmount" runat="server" Text="1"></asp:Label>
                            <asp:Button ID="btnReduce" runat="server" Text="-" CommandName="reduce" CommandArgument='<%# Container.DataItemIndex%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="小计">
                        <ItemTemplate>
                            <asp:Label ID="labCount" runat="server" Text="1"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" Text="删除" CommandName="remove" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="javascript:return confirm('是否删除')" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <p></p>
        <table class="dataTable" style="width: 98%">
            <tr>
                <td style="width: 400px; text-align: left; padding: 0 5px; height: 30px; line-height: 30px">购物金额小计： <font color="#FF7126" style="font-weight: bold">
                          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>元</font>
                    比售价<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>元 节省了 <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>元
                </td>
                <td style="padding: 0 5px; height: 30px; line-height: 30px; text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="清除购物车" OnClick="Button1_Click"/>&nbsp;&nbsp;
                </td>
            </tr>
        </table>
        <p></p>
        <table style="width: 98%">
            <tr>
                <td style="text-align: left">
                    <a href="Main.aspx">
                        <img src="Content/Images/goShop.png" style="border: 0px" />
                    </a>
                </td>
                <td style="text-align: right">
                    <a href="BalancePage.aspx">
                        <img src="Content/Images/goOrder.png" style="border: 0px" />
                    </a>
                </td>
            </tr>
        </table>
    </div>
    <!--中部结束-->
</asp:Content>
