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
    public partial class Region1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnZC_Click(object sender, EventArgs e)
        {
            string UName = txtname.Text.Trim();
            if (string.IsNullOrEmpty(UName))
            { Response.Write("<script>alert('请输入用户名！')</script>"); return; }
            string Uemail = txtemail.Text.Trim();
            if (string.IsNullOrEmpty(Uemail))
            { Response.Write("<script>alert('请输入email！')</script>"); return; }
            string Upwd = txtpwd.Text.Trim();
            if (string.IsNullOrEmpty(Upwd))
            { Response.Write("<script>alert('请输入密码！')</script>"); return; }
            string Upwd1 = txtpwd1.Text.Trim();
            if (string.IsNullOrEmpty(Upwd1))
            { Response.Write("<script>alert('请输入确认密码！')</script>"); return; }
            if (Upwd != Upwd1) { Response.Write("<script>alert('两次输入密码不一致，请重新输入！')</script>"); return; }
            string Usex = rbtnSex.SelectedValue.Trim();
            string Unick = txtUnick.Text.Trim();
            if (string.IsNullOrEmpty(Unick))
            { Response.Write("<script>alert('请输入所属姓名！')</script>"); return; }
            Users info = new Users();
            info.UserName = UName;
            info.UserEmail = Uemail;
            info.UserPwd = Upwd;
            info.UserSex = Usex;
            info.UserNick = Unick;
            if (UsersBll.Insert(info))
            {
                Response.Write("<script>alert('注册成功！')</script>");
                Response.Redirect("Login.aspx");
            }
            else { Response.Write("<script>alert('添加失败！')</script>"); }
        }
    }
}