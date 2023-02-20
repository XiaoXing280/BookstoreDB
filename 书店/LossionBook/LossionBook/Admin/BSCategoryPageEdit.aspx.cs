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
    public partial class BSCategoryPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //显示页面初始数据
                //接收传入值
                string BSID = Request.QueryString["id"];
                //根据ID查询小类别数据
                BSCategory info = BSCategoryPageBll.SeletByID(BSID);
                //绑定输入框
                txtBSName.Text = info.BSName;
                //绑定下拉框
                DropDownList1.DataSource = BLCategoryPageBll.SeletAll();
                DropDownList1.DataTextField = "BLName";//设定dorpDownList选中项的显示值
                DropDownList1.DataValueField = "BLID";//设定dorpDownList选中项的关联值
                DropDownList1.DataBind();
                //选定下拉框
                DropDownList1.SelectedValue= info.BLID.ToString();
            }
        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }

        protected void btnQD_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBSName.Text))
            { Response.Write("<script>alert('请输入编辑的小类别名称！')</script>"); return; }
            BSCategory info = new BSCategory();
            info.BSName = txtBSName.Text;
            info.BLID= int.Parse(this.DropDownList1.SelectedItem.Value);
            info.BSID = int.Parse(Request.QueryString["id"]);
            if (BSCategoryPageBll.Update(info))
            {
                Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
            }
            else { Response.Write("<script>alert('编辑失败！')</script>"); }
        }
    }
}