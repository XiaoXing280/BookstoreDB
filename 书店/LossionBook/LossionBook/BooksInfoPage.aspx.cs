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
    public partial class BooksInfoPage : System.Web.UI.Page  
    {
        public int BSID = 0;
        public int BLID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //书籍信息
                int BookID = int.Parse(Request.QueryString["BookID"].ToString());
                Rep_Book.DataSource =BooksPageBll.SeletAllBookID(BookID);
                Rep_Book.DataBind();
                //设置传值
                //根据书籍查小类别ID
                BSID = (int)BooksPageBll.SeletAllByID(BookID).BSID;
                //根据小类别查询大类别
                BLID = (int)BSCategoryPageBll.SeletByID((BSID).ToString()).BLID;
                //层级菜单
                if (BLID != 0)
                {
                    BLCategory BLinfo = BLCategoryPageBll.SeletByID(BLID.ToString());
                    lblBLName.Text = BLinfo.BLName;
                }
                //传入小类别
                if (BSID != 0)
                {
                    BSCategory BSinfo = BSCategoryPageBll.SeletByID(BSID.ToString());
                    lblBSName.Text = BSinfo.BSName;
                    lblBLName.Text = BLCategoryPageBll.SeletByID((BSinfo.BLID).ToString()).BLName;
                }
                //评价
                Rep_BookAppraise.DataSource = BookAppraiseBll.GetModelListBySqlStr(BookID);
                Rep_BookAppraise.DataBind();
            }
        }

        protected void Rep_Book_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Buy")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Dictionary<int, int> flow = new Dictionary<int, int>();
                if (Session["flow"] != null)
                {
                    flow = Session["flow"] as Dictionary<int, int>;
                }
                if (flow.ContainsKey(id))
                {
                    flow[id] += 1;
                }
                else
                {
                    flow.Add(id, 1);
                }
                Session["flow"] = flow;
                //判断库存
                Dictionary<int, int> dic = Session["flow"] as Dictionary<int, int>;
                List<Books> list = BooksPageBll.SelectForIDS(dic);
                foreach (var books in list)
                {
                    foreach (var bookid in dic.Keys)
                    {
                        if (bookid == books.BookID && dic[bookid] > books.BookDeport)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('库存就这么多了！')", true);
                            if (dic[bookid] > 0)
                            {
                                dic[bookid] -= 1;
                                //购买数量为0时删除本行
                                if (dic[bookid] <= 0)
                                {
                                    dic.Remove(bookid);
                                    //书本数量为0时删除Session
                                    if (dic.Count == 0)
                                    {
                                        Session["flow"] = null;
                                    }
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}