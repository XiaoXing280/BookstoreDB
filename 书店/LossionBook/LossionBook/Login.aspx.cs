using BookBll;
using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string UName = txtname.Text;
            string UPwd = txtpwd.Text;
            //非空验证
            if (string.IsNullOrEmpty(UName))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入用户名')", true); return;
            }
            if (string.IsNullOrEmpty(UPwd))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入密码')", true); return;
            }
            Users info = UsersBll.login(UName, UPwd);
            if (info!=null)
            {
                Session["user"] = info;
                Response.Redirect("Main.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('用户名或密码错误，请重新输入！')", true);
                return;
            }
        }
    }
}