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
    public partial class Main : System.Web.UI.MasterPage
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
            //绑定头部大类别
            repHelp.DataSource = BLCategoryPageBll.SeletAll();
            repHelp.DataBind();
            //绑定左侧类别
            repBLName.DataSource = BLCategoryPageBll.SeletAll();
            repBLName.DataBind();
            List<Books> info = BooksPageBll.SeletAllByBookSale();
            repBookSale.DataSource = info;
            repBookSale.DataBind();
        }

        protected void repBLName_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //通过控件ID查找内层的Repeater控件
                Repeater rep = e.Item.FindControl("repBSName") as Repeater;
                //获取当前绑定项对应的绑定数据
                int blID = (int)(e.Item.DataItem as BLCategory).BLID;
                //根据大类别的ID查询出对应的小类别，并绑定到内层Repeater中
                //在页面加载时查询所有的小类别，并定义为全局变量
                //每次绑定内层Repeater时，不需要每个大类别都查询一次数据库，而是从内存中检索数据
                rep.DataSource = BSCategoryPageBll.SeletAll(blID);
                rep.DataBind();
            }
        }

        protected void btnZX_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}