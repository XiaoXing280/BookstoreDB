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
    public partial class BLCategoryPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
             //显示页面初始数据
            string BLID = Request.QueryString["id"];
            BLCategory info = BLCategoryPageBll.SeletByID(BLID);
            txtBLName.Text = info.BLName;
            }
        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            //关闭窗口
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }

        protected void btnQD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBLName.Text))
            { Response.Write("<script>alert('请输入编辑的大类别名称！')</script>"); return; }
            BLCategory info = new BLCategory();
            info.BLName = txtBLName.Text;
            info.BLID = int.Parse(Request.QueryString["id"]);
            if (BLCategoryPageBll.Update(info))
            {
                Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else { Response.Write("<script>alert('编辑失败！')</script>"); }
        }
    }
}