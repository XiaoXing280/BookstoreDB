using BookBll;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook.Admin
{
    public partial class OrderDetailPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                int OrderID = int.Parse(Request.QueryString["OrderID"]);
                View_Orders info = OrderPageBll.SelectByID(OrderID);
                lblOrderNum.Text = info.OrderNum;
                lblOrderDate.Text = info.OrderDate.ToString();
                lblOrderMoney.Text = info.OrderMoney.ToString();
                lblOrderState.Text = info.OrderState.ToString();
                lblUserName.Text = info.UserName;
                lblUserNick.Text = info.UserNick;
                lblAMTel.Text = info.AMTel;
                lblAMAddress.Text = info.AMAddress;
                GridView1.DataSource = OrderDetailBll.SelectAll(OrderID);
                GridView1.DataBind();
            }
        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            //关闭窗体
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
    }
}