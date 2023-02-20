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
    public partial class Main1 : System.Web.UI.Page
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
            List<Books> booksinfo = BooksPageBll.SeletAllByISBuy();
            repBuy.DataSource = booksinfo;
            repBuy.DataBind();
            List<Books> info = BooksPageBll.SeletAllByISHot();
            repHot.DataSource = info;
            repHot.DataBind();
        }

        protected void repBuy_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="buy") 
            {
                int id = int.Parse(e.CommandArgument.ToString());
                //在session中存储购物车信息
                Dictionary<int, int> flow = new Dictionary<int, int>();
                if (Session["flow"] != null)
                {
                    flow = (Dictionary<int, int>)Session["flow"];
                }
                //存在累加，不存在添加
                if (flow.ContainsKey(id))
                {
                    flow[id] = flow[id] + 1;
                }
                else
                {
                    flow.Add(id, 1);
                }
                Session["flow"] = flow;
            }

        }

        protected void repHot_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "buy")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                //在session中存储购物车信息
                Dictionary<int, int> flow = new Dictionary<int, int>();
                if (Session["flow"] != null)
                {
                    flow = (Dictionary<int, int>)Session["flow"];
                }
                //存在累加，不存在添加
                if (flow.ContainsKey(id))
                {
                    flow[id] = flow[id] + 1;
                }
                else
                {
                    flow.Add(id, 1);
                }
                Session["flow"] = flow;
            }
        }
    }
}