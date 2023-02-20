using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookBll;
using BookModel;

namespace LossionBook.Admin
{
    public partial class OrderPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                Bind();
                BindGrid(1);
            }
        }
        private void Bind() 
        {
            //利用Dictionary泛型集合绑定订单状态
            Dictionary<int, string> dics = new Dictionary<int, string>();
            dics.Add(0, "全部");
            dics.Add(1, "待确认");
            dics.Add(2, "已确认");
            dics.Add(3, "已发货");
            dics.Add(4, "已完成");
            DropDownList1.DataSource = dics;
            DropDownList1.DataTextField = "Value";
            DropDownList1.DataValueField = "Key";
            DropDownList1.DataBind();
            this.GridView1.DataSource = OrderPageBll.SeletAll();
            this.GridView1.DataBind();
        }
        private void BindGrid(int index)
        {
            OrdersSelect info = new OrdersSelect();
            if (ViewState["Info"] != null)
            {
                info = ViewState["Info"] as OrdersSelect;
            }
            info.PageIndex = index;
            info.PageSize = 10;
            GridView1.DataSource =OrderPageBll.SelectBookPage(info);
            GridView1.DataBind();
            //计算总页数
            int pageCount = (info.DataCount - 1) / info.PageSize + 1;
            this.labCurrent.Text = pageCount.ToString();
            this.labCount.Text = index.ToString();
            ViewState["index"] = index;

        }
        protected void btnCX_Click(object sender, EventArgs e)
        {
            OrdersSelect info = new OrdersSelect();
            if (!string.IsNullOrEmpty(txtOrderNum.Text)) 
            {info.OrderNum = txtOrderNum.Text; }
            if (!string.IsNullOrEmpty(txtUserNick.Text)) 
            {info.UserNick = txtUserNick.Text; }
            info.OrderState = int.Parse(DropDownList1.SelectedValue);
            info.OrderDateStart =Calendar1.Text;
            info.OrderDateEnd = Calendar2.Text;
            ViewState["Info"] = info;
            BindGrid(1);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSY_Click(object sender, EventArgs e)
        {
            BindGrid(1);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnON_Click(object sender, EventArgs e)
        {
            int index = (int)ViewState["index"];
            BindGrid(index > 1 ? index - 1 : 1);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDOWN_Click(object sender, EventArgs e)
        {
            int index = (int)ViewState["index"];
            int endindex = int.Parse(labCount.Text);
            BindGrid(index < endindex ? index + 1 : endindex);
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWY_Click(object sender, EventArgs e)
        {
            int endIndex = int.Parse(labCount.Text);
            BindGrid(endIndex);
        }
        /// <summary>
        /// 跳转页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtindex.Text);
            int sum = int.Parse(labCount.Text);
            if (index <= 0 || index > sum)
            {
                Response.Write("<script>alert('请输入在范围内的页数！')</script>"); return;
            }
            BindGrid(index);
        }
        /// <summary>
        /// GridView中列中数据替换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "1")
                {
                    e.Row.Cells[4].Text = "待确定";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "确定";
                }
                if (e.Row.Cells[4].Text == "2")
                {
                    e.Row.Cells[4].Text = "已确定";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "发货";
                }
                if (e.Row.Cells[4].Text == "3")
                {
                    e.Row.Cells[4].Text = "待发货";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "完成";
                }
                if (e.Row.Cells[4].Text == "4")
                {
                    e.Row.Cells[4].Text = "完成";
                    (e.Row.Cells[5].FindControl("Btn_Edit") as LinkButton).Text = "";
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DoEdit")
            {
                //根据id查到所有值赋给b
                var b= OrderPageBll.SeletAllByID(int.Parse(e.CommandArgument.ToString()));
                //建一个Orders存数据
                Orders info = new Orders();
                info.UserID = b.UserID;
                info.AMID = b.AMID;
                info.OrderID = b.OrderID;
                info.OrderDate = b.OrderDate;
                info.OrderNum = b.OrderNum;
                info.OrderState = b.OrderState+1;
                info.OrderMoney = b.OrderMoney;
                //判断进行修改操作
                if (OrderPageBll.Update(info))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('操作成功！')", true);
                    BindGrid(1);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('操作失败！')", true);
                }
            }
        }
    }
}