using BookBll;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LossionBook
{
    public partial class CategoryPage : System.Web.UI.Page
    {
        //声明公共参数：传入值（大小类别）
        public int BLID = 0;
        public int BSID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置传值(点击首页中大小类别)
                if (Request.QueryString.Count != 0)
                {
                    //传入小类别
                    if (Request.QueryString.AllKeys[0] == "BSID")
                    {
                        BSID = int.Parse(Request.QueryString["BSID"].ToString().Trim());
                        //根据小类别查询大类别
                        BLID = (int)BSCategoryPageBll.SeletByID((BSID).ToString()).BLID;
                    }
                    //传入大类别
                    else if (Request.QueryString.AllKeys[0] == "BLID")
                    {
                        BLID = int.Parse(Request.QueryString["BLID"].ToString().Trim());
                    }
                }
                //绑定数据
                Bind(1);
            }
        }
        /// <summary>
        /// 页面详细数据绑定
        /// </summary>
        private void Bind(int index)
        {
            BooksSelect info = new BooksSelect();
            if (BLID != 0) { info.BLID = BLID; }
            if (BSID != 0) { info.BSID = BSID; }
            info.PageIndex = index;
            info.PageSize = 5;
            rep_Table.DataSource = BooksPageBll.SelectBookPage(info);
            rep_Table.DataBind();
            //传入大类别
            if (BLID != 0)
            {
                BLCategory BLinfo = BLCategoryPageBll.SeletByID(BLID.ToString());
                lblBLName.Text = BLinfo.BLName;
            }
            //传入小类别
            if (BSID != 0)
            {
                BSCategory BSinfo = BSCategoryPageBll.SeletByID(BSID.ToString());
                lblBSName.Text = BSinfo.BSName;
                lblBLName.Text = BLCategoryPageBll.SeletByID((BSinfo.BLID).ToString()).BLName;
            }
            //计算总页数
            int pageCount = (info.DataCount + info.PageSize - 1) / info.PageSize;
            //当前页
            labCurrent.Text = index.ToString();
            //总页数
            labCount.Text = pageCount.ToString();
            ViewState["index"] = index;
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSY_Click(object sender, EventArgs e)
        {
            txtindex.Text = labCurrent.Text;
            Bind(1);
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
            Bind(index > 1 ? index - 1 : 1);
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
            Bind(index < endindex ? index + 1 : endindex);
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
            Bind(endIndex);
        }
        /// <summary>
        /// 跳转页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button2_Click(object sender, EventArgs e)
        {
            int index = int.Parse(txtindex.Text);
            int sum = int.Parse(labCount.Text);
            if (index <= 0 || index > sum)
            {
                Response.Write("<script>alert('请输入在范围内的页数！')</script>"); return;
            }
            Bind(index);
        }
    }
}