using System;
using BookBll;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook.Admin
{
    public partial class BLCategoryPage : BasePage
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
            this.GridView1.DataSource = BLCategoryPageBll.SeletAll();
            this.GridView1.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BLID = Convert.ToInt32(e.Keys["BLID"]);
            if (BLCategoryPageBll.Deleter(BLID))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Bind();
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }  


        }
    }
}