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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string txtUserName = this.txtUserName.Text;
            string txtPassWord = this.txtPassWord.Text;
            string txtvalicode = this.txtvalicode.Text;
            Admins info = new Admins();
            info.AdminUser = txtUserName;
            info.AdminPwd = txtPassWord;
            //非空验证
            if (string.IsNullOrEmpty(txtUserName)) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入用户名')", true); return;
            }
            if (string.IsNullOrEmpty(txtPassWord))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入密码')", true); return;
            }
            if (string.IsNullOrEmpty(txtvalicode))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入验证码')", true); return;
            }
            //验证码验证
            if (txtvalicode != Session["validateCode"].ToString()) 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(),"msg","layer.msg('验证码错误')",true) ;
                return;
            }
            if (AdminsBll.login(info))
            {
                Session["admin"]= info;
                Response.Redirect("Index.aspx");
            }
            else 
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('用户名或密码错误，请重新输入！')", true);
                return;
            }
        }
    }
}