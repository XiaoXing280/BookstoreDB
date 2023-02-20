using BookBll;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class flowPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind()
        {
            try
            {
                if (Session["flow"] != null)
                {
                    Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                    List<Books> list = BooksPageBll.SelectForIDS(dic);
                    GridView1.DataSource = list;
                    GridView1.DataBind();
                    float money = 0;
                    float price = 0;
                    foreach (Books item in list)
                    {
                        int count = dic[(int)item.BookID];
                        money += count * (float)item.BookMoney;
                        price += count * (float)item.BookPrice;
                    }
                    Label1.Text = string.Format("{0:C}", money);
                    Label2.Text = string.Format("{0:C}", price);
                    Label3.Text = string.Format("{0:C}", (price - money));
                }

            }
            catch
            {
                // Response.Write(ex.Message);
                Server.ClearError();
            }
        }
        /// <summary>
        /// 对商品列表数量操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                int index = int.Parse(e.CommandArgument.ToString());
                int id = (int)GridView1.DataKeys[index].Value;
                //数量+1
                if (e.CommandName == "add")
                {
                    dic[id] += 1;
                    Label labAmount = GridView1.Rows[index].FindControl("labAmount") as Label;
                    labAmount.Text = dic[id].ToString();
                }
                //数量-1
                else if (e.CommandName == "reduce")
                {
                    if (dic[id] > 0)
                    {
                        dic[id] -= 1;
                        Label labAmount = GridView1.Rows[index].FindControl("labAmount") as Label;
                        labAmount.Text = dic[id].ToString();
                        //数量减为0时删除本行
                        if (dic[id]<=0) 
                        {
                            dic.Remove(id);
                            //全部书本数量为0时删除Session
                            if (dic.Count == 0)
                            {
                                Session["flow"] = null;
                                Response.Redirect("flowPage.aspx");
                            }
                        }
                    }
                }
                //删除本行
                else if (e.CommandName == "remove")
                {
                    dic.Remove(id);
                }
                Session["flow"] = dic;
                Bind();
            }
            catch (Exception ex) { throw ex; }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
                {
                    float price = float.Parse(e.Row.Cells[2].Text);
                    float money = float.Parse(e.Row.Cells[1].Text);
                    e.Row.Cells[1].Text = money.ToString("C");
                    e.Row.Cells[2].Text = price.ToString("C");
                    int id = (int)GridView1.DataKeys[e.Row.RowIndex].Value;
                    Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                    int amount = dic[id];
                    Label labAmount = e.Row.FindControl("labAmount") as Label;
                    Label labCount = e.Row.FindControl("labCount") as Label;
                    labAmount.Text = amount.ToString();
                    labCount.Text = string.Format("{0:C}", price * amount);
                }
            }
            catch (Exception ex) { throw ex; }
        }
        /// <summary>
        /// 清空购物车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["flow"] = null;
            Response.Redirect("flowPage.aspx");
        }
    }
}