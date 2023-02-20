using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook.Admin
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //加载图片
            System.Drawing.Image im = System.Drawing.Image.FromFile(Server.MapPath("../Content/Images/vali.jpg"));
            //获取绘图工具
            Graphics g = Graphics.FromImage(im);
            //使用Random生成4位数的随机数
            Random rand = new Random();
            int code = rand.Next(1000,10000);
            //保存到session中
            Session["validateCode"] = code;
            //在图片上绘制文字
            g.DrawString(code.ToString(), new Font("宋体", 20), new SolidBrush(Color.Black), 0, 0);
            //保存时使用响应对象的流将图片发送到客服端
            im.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //客户端响应类型
            Response.ContentType = "Image/jpeg";
            //结束当前页面的处理
            Response.End();
        }
    }
}