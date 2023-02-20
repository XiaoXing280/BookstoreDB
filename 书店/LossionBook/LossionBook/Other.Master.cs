using BookBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class Other : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                //绑定头部大类别
                repHelp.DataSource = BLCategoryPageBll.SeletAll();
                repHelp.DataBind();
            }

        }

        protected void btnZX_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}