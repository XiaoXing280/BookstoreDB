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
    public partial class BLCategoryPageADD : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnQD_Click(object sender, EventArgs e)
        {
            string txtBLName = this.txtBLName.Text;
            if (string.IsNullOrEmpty(txtBLName))
            { Response.Write("<script>alert('请输入你要添加大类别的名称！')</script>"); return; }
            BLCategory info = new BLCategory();
            info.BLName = txtBLName;
            if (BLCategoryPageBll.Insert(info))
            {
                Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else { Response.Write("<script>alert('添加失败！')</script>"); }

        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            //关闭窗体
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }
    }
}