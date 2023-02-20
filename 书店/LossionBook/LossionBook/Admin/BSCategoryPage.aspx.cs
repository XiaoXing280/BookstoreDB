using System;
using BookBll;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BookModel;

namespace LossionBook.Admin
{
    public partial class BSCategoryPage : BasePage
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
            this.GridView1.DataSource = BSCategoryPageBll.SeletAll();
            this.GridView1.DataBind();
            //下拉框绑定值
            DropDownList1.DataSource = BLCategoryPageBll.SeletAll();
            DropDownList1.DataTextField = "BLName";//设定dorpDownList选中项的显示值
            DropDownList1.DataValueField = "BLID";//设定dorpDownList选中项的关联值
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("请选择","0"));
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BSID = Convert.ToInt32(e.Keys["BSID"]);
            if (BSCategoryPageBll.Deleter(BSID))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Bind();
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int BLID = int.Parse(this.DropDownList1.SelectedItem.Value);
            if (BLID == 0)
            {
                Bind();
            }
            else {
                this.GridView1.DataSource = BSCategoryPageBll.SeletAll(BLID);
                this.GridView1.DataBind();
            }
        }
    }
}