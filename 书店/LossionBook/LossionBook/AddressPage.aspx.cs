using BookBll;
using BooKModel;
using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class AddressPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            if (!IsPostBack)
            {
                Bind();
            }
        }
        private void Bind() 
        {
            Users user = Session["user"] as Users;
            Repeater1.DataSource = AddressManagerBll.SelectForUser((int)user.UserID);
            Repeater1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Users user = Session["user"] as Users;
            AddressManager info = new AddressManager();
            info.AMUser = txtName.Text.Trim();
            info.AMTel = txtTel.Text.Trim();
            info.AMAddress = txtAdd.Text.Trim();
            info.AMMark = false;
            info.UserID = user.UserID;
            AddressManagerBll.Insert(info);
            Bind();
            txtName.Text = "";
            txtTel.Text = "";
            txtAdd.Text = "";
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //设置默认按钮是否禁用
                AddressManager info = e.Item.DataItem as AddressManager;
                if ((bool)info.AMMark)
                {
                    Button btn = e.Item.FindControl("btnDefault") as Button;
                    btn.Enabled = false;
                }
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "save")
            {
                AddressManager info = AddressManagerBll.SelectForID(id);
                info.AMUser = (e.Item.FindControl("TextBox1") as TextBox).Text.Trim();
                info.AMTel = (e.Item.FindControl("TextBox2") as TextBox).Text.Trim();
                info.AMAddress = (e.Item.FindControl("TextBox3") as TextBox).Text.Trim();
                AddressManagerBll.Update(info);
            }
            else if (e.CommandName == "default")
            {
                Users user = Session["user"] as Users;
                AddressManagerBll.UpdateDefault(id, (int)user.UserID);
            }
            else if (e.CommandName == "delete")
            {
                AddressManagerBll.Delete(id);
            }
            Bind();
        }

    }
}