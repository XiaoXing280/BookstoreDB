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
    public partial class BooksPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
                BindPage(1);
            }
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
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

            //利用Dictionary泛型集合绑定是与否的值
            Dictionary<int, string> dics = new Dictionary<int, string>();
            dics.Add(-1, "全部");
            dics.Add(1, "是");
            dics.Add(0, "否");
            //绑定是否秒杀下拉框
            drpBookIsBuy.DataSource = dics;
            drpBookIsBuy.DataTextField = "Value";
            drpBookIsBuy.DataValueField = "Key";
            drpBookIsBuy.DataBind();
            //绑定是否热门下拉框
            drpBookIsHot.DataSource = dics;
            drpBookIsHot.DataTextField = "Value";
            drpBookIsHot.DataValueField = "Key";
            drpBookIsHot.DataBind();
        }

        private void BindPage(int index)
        {
            BooksSelect info = new BooksSelect();
            //ViewState["select"]查询后保留的数据
            if (ViewState["select"] != null)
            {
                info = ViewState["select"] as BooksSelect;
            }
            info.PageIndex = index;
            info.PageSize = 10;
            GridView1.DataSource = BooksPageBll.SelectBookPage(info);
            GridView1.DataBind();
            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            labCurrent.Text = index.ToString();  //当前页
            labCount.Text = pageCount.ToString();   //总页数
            ViewState["index"] = index;
        }
        /// <summary>
        /// 选定大类别后小类别的对应绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void drpBLName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取当前选中的大类别ID
            int BLID = int.Parse(drpBLName.SelectedValue);
            drpBSName.DataSource = BSCategoryPageBll.SeletAll(BLID);
            drpBSName.DataTextField = "BSName";
            drpBSName.DataValueField = "BSID";
            drpBSName.DataBind();
            drpBSName.Items.Insert(0, new ListItem("全部", "0"));
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCX_Click(object sender, EventArgs e)
        {
            BooksSelect info = new BooksSelect();
            if (!string.IsNullOrEmpty(txtBookTitle.Text))
            { info.BookTitle = txtBookTitle.Text; }
            if (!string.IsNullOrEmpty(txtBookPublish.Text))
            { info.BookPublish = txtBookPublish.Text; }
            if (drpBookIsBuy.SelectedIndex != -1)
            { info.BookIsBuy = int.Parse(drpBookIsBuy.SelectedValue); }
            if (drpBookIsHot.SelectedIndex != -1)
            { info.BookIsHot = int.Parse(drpBookIsHot.SelectedValue); }
            if (drpBLName.SelectedIndex != 0)
            { info.BLID = int.Parse(drpBLName.SelectedValue); }
            if (drpBSName.SelectedIndex != 0)
            { info.BSID = int.Parse(drpBSName.SelectedValue); }
            ViewState["select"] = info;
            BindPage(1);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSY_Click(object sender, EventArgs e)
        {
            int a = 1;
            txtindex.Text = a.ToString();
            BindPage(1);
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnON_Click(object sender, EventArgs e)
        {
            int index = (int)ViewState["index"];
            txtindex.Text = (index > 1 ? index - 1 : 1).ToString();
            BindPage(index > 1 ? index - 1 : 1);
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDOWN_Click(object sender, EventArgs e)
        {
            int index = (int)ViewState["index"];
            int endindex = int.Parse(labCount.Text);
            txtindex.Text = (index < endindex ? index + 1 : endindex).ToString();
            BindPage(index < endindex ? index + 1 : endindex);
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnWY_Click(object sender, EventArgs e)
        {
            txtindex.Text = labCount.Text;
            int endIndex = int.Parse(labCount.Text);
            BindPage(endIndex);
        }
        /// <summary>
        /// 跳转页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            int index =int.Parse(txtindex.Text);
            int sum = int.Parse(labCount.Text);
            if (index<=0||index>sum) 
            {
                Response.Write("<script>alert('请输入在范围内的页数！')</script>"); return;
            }
            BindPage(index);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int BookID = Convert.ToInt32(e.Keys["BookID"]);
            if (BooksPageBll.Deleter(BookID))
            {
                Response.Write("<script>alert('删除成功！')</script>");
                Bind();
            }
            else
            {
                Response.Write("<script>alert('删除失败！')</script>");
            }
        }
        /// <summary>
        /// 替换表格bool类型数据文字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate) && e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.Cells[8].Text = bool.Parse(e.Row.Cells[8].Text) ? "是" : "否";
                e.Row.Cells[9].Text = bool.Parse(e.Row.Cells[9].Text) ? "是" : "否";
            }
        }

    }
}