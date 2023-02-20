using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook.Admin
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["admin"]==null) 
            {
                Response.Write("<script>window.location.href='Login.aspx';</script>");
                Response.End();
            }
        }
    }
}