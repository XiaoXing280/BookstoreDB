using BookBll;
using BookModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook.Admin
{
    public partial class BooksPageEdit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Request.QueryString["BookID"] == null)
                {
                    this.Title = "书籍添加";
                    Bind();
                }
                else 
                {
                    this.Title = "书籍编辑";
                    int BookID = int.Parse(Request.QueryString["BookID"]);
                    Books info = BooksPageBll.SeletAllByID(BookID);
                    txtBookTitle.Text = info.BookTitle;
                    txtBookAuthor.Text = info.BookAuthor;
                    txtBookPublish.Text = info.BookPublish;
                    imgISBN.ImageUrl = "../BookImages/" + info.ISBN.ToString().Trim() + ".jpg";
                    //绑定大类别下拉框
                    drpBLName.DataSource = BLCategoryPageBll.SeletAll();
                    drpBLName.DataTextField = "BLName";//设定dorpDownList选中项的显示值
                    drpBLName.DataValueField = "BLID";//设定dorpDownList选中项的关联值
                    drpBLName.DataBind();
                    //选定下拉框
                    drpBLName.SelectedValue = info.BLID.ToString();
                    //绑定小类别
                    drpBSName.DataSource = BSCategoryPageBll.SeletAll(info.BLID);
                    drpBSName.DataTextField = "BSName";
                    drpBSName.DataValueField = "BSID";
                    drpBSName.DataBind();
                    //选定下拉框
                    drpBSName.SelectedValue = info.BSID.ToString();
                    txtBookPrice.Text = info.BookPrice.ToString();
                    txtBookMoney.Text= info.BookMoney.ToString();
                    txtBookCount.Text = info.BookCount.ToString();
                    txtBookDeport.Text= info.BookDeport.ToString();
                    BookDesc.Value = info.BookDesc;
                    BookAuthorDesc.Value = info.BookAuthorDesc;
                    BookComm.Value = info.BookComm;
                    BookContent.Value = info.BookContent;
                }
            }

        }
        private void Bind()
        {
            //下拉框绑定值
            drpBLName.DataSource = BLCategoryPageBll.SeletAll();//绑定大类别
            drpBLName.DataTextField = "BLName";//大类别选中项的显示值
            drpBLName.DataValueField = "BLID";//大类别选中项的关联值
            drpBLName.DataBind();//绑定大类别值
            drpBLName.Items.Insert(0, new ListItem("全部", "0"));//添加大类别的一条数据
            //给小类别添加第一条数据
            var list = BSCategoryPageBll.SeletAll();
            list.Insert(0, new BSCategory() { BSID = 0, BSName = "全部" });
            drpBSName.DataSource = list;//绑定小类别
            drpBSName.DataTextField = "BSName";//大类别选中项的显示值
            drpBSName.DataValueField = "BSID";//大类别选中项的关联值
            drpBSName.DataBind();//绑定小类别值
        }

        protected void drpBLName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 获取当前选中的大类别ID
            int BLID = int.Parse(drpBLName.SelectedValue);
            drpBSName.DataSource = BSCategoryPageBll.SeletAll(BLID);
            drpBSName.DataTextField = "BSName";
            drpBSName.DataValueField = "BSID";
            drpBSName.DataBind();
            drpBSName.Items.Insert(0, new ListItem("全部", "0"));
        }

        protected void btnQX_Click(object sender, EventArgs e)
        {
            //关闭窗口
            Response.Write("<script>var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
        }

        protected void btnQD_Click(object sender, EventArgs e)
        {
            Books info = new Books();
            if (string.IsNullOrEmpty(txtBookTitle.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入书籍名称')", true); return; }
            info.BookTitle = txtBookTitle.Text;
            if (string.IsNullOrEmpty(txtBookAuthor.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入作者')", true); return; }
            info.BookAuthor = txtBookAuthor.Text;
            if (string.IsNullOrEmpty(txtBookPublish.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入出版社')", true); return; }
            info.BookPublish = txtBookPublish.Text;
            //上传文件
            string fileName = ulPhoto.FileName;//截取文件名字（包括后缀名）
            if (!string.IsNullOrEmpty(fileName))
            {
                //判断文件格式
                if (fileName.EndsWith(".jpg"))
                {
                    //获取服务器保存的绝对路径
                    string fuldUIL = Server.MapPath(@"../BookImages/" + fileName);
                    //保存文件
                     ulPhoto.SaveAs(fuldUIL);
                    //
                    info.ISBN= fileName.Substring(0,fileName.LastIndexOf('.'));
                }
                else
                {
                    Response.Write("<script>alert('图片格式不对!非.jpg文件')</script>");
                }
            }
            info.BLID = int.Parse(drpBLName.SelectedValue);
            info.BSID = int.Parse(drpBSName.SelectedValue);
            if (decimal.Parse(txtBookPrice.Text)<0||string.IsNullOrEmpty(txtBookPrice.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入正确的标价')", true); return; }
            info.BookPrice =decimal.Parse(txtBookPrice.Text);
            if (decimal.Parse(txtBookMoney.Text) < 0 || string.IsNullOrEmpty(txtBookMoney.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入正确的售价')", true); return; }
            info.BookMoney = decimal.Parse(txtBookMoney.Text);
            if (int.Parse(txtBookCount.Text) < 0 || string.IsNullOrEmpty(txtBookCount.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入正确的字数')", true); return; }
            info.BookCount = int.Parse(txtBookCount.Text);
            if (int.Parse(txtBookDeport.Text) < 0 || string.IsNullOrEmpty(txtBookDeport.Text))
            { ScriptManager.RegisterStartupScript(this, this.GetType(), "msg", "layer.msg('请输入正确的初始库存')", true); return; }
            info.BookDeport = int.Parse(txtBookDeport.Text);
            info.BookDesc = BookDesc.Value;
            info.BookAuthorDesc = BookAuthorDesc.Value;
            info.BookComm = BookComm.Value;
            info.BookContent = BookContent.Value;
            if (Request.QueryString["BookID"] != null) 
            {
                info.BookID = int.Parse(Request.QueryString["BookID"]);
                if (BooksPageBll.Update(info))
                {
                    Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
                }
                else { Response.Write("<script>alert('编辑失败！')</script>"); }
            }
            else 
            {
                info.BookSale =100;
                info.BookIsHot = true;
                info.BookIsBuy = false;
                info.BookIsDelete = false;
                if (BooksPageBll.Insert(info))
                {
                    Response.Write(@"<script>window.parent.location.reload();
                var index = parent.layer.getFrameIndex(window.name);parent.layer.close(index);</script>");
                }
                else { Response.Write("<script>alert('添加失败！')</script>"); }
            }
        }
    }
}