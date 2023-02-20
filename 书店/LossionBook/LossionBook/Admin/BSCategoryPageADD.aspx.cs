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
    public partial class BSCategoryPageADD : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList1.DataSource = BLCategoryPageBll.SeletAll();
                DropDownList1.DataTextField = "BLName";//设定dorpDownList选中项的显示值
                DropDownList1.DataValueField = "BLID";//设定dorpDownList选中项的关联值
                DropDownList1.DataBind();
            }

        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }

        protected void btnQD_Click(object sender, EventArgs e)
        {
            string txtBSName = this.txtBSName.Text;
            if (string.IsNullOrEmpty(txtBSName))
            { Response.Write("<script>alert('请输入你要添加小类别的名称！')</script>");return; }
            BSCategory info = new BSCategory();
            int BLID = int.Parse(this.DropDownList1.SelectedItem.Value);
            info.BSName = txtBSName;
            info.BLID = BLID;
            if (BSCategoryPageBll.Insert(info))
            {
                Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else { Response.Write("<script>alert('添加失败！')</script>"); }
        }
    }
}