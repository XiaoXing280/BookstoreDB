using BookModel;
using BookDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksModel;

namespace BookBll
{
    public class BooksPageBll
    {
        public static List<Books> SeletAll()
        {
            return BooksPageDal.SeletAll();
        }
        public static List<Books> SeletAllBookID(int BookID)
        {
            return BooksPageDal.SeletAllBookID(BookID);
        }
        public static Books SeletAllByID(int BookID)
        {
            return BooksPageDal.SeletAllByID(BookID);
        }
        /// <summary>
        /// 根据是否前端热销查询前五条数据
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public static List<Books> SeletAllByISBuy() 
        {
            return BooksPageDal.SeletAllByISBuy();
        }
        /// <summary>
        /// 根据是否热门前端查询前十条数据
        /// </summary>
        /// <returns></returns>
        public static List<Books> SeletAllByISHot() 
        {
            return BooksPageDal.SeletAllByISHot();
        }
        /// <summary>
        /// 按照销售数量排行，找前五条数据
        /// </summary>
        /// <returns></returns>
        public static List<Books> SeletAllByBookSale() 
        {
            return BooksPageDal.SeletAllByBookSale();
        }
        /// <summary>
        /// 对前端订单的查询
        /// </summary>
        /// <param name="dis"></param>
        /// <returns></returns>
        public static List<Books> SelectForIDS(Dictionary<int, int> dis)
        {
            string ids = "";
            foreach (var item in dis.Keys)
            {
                ids += item + ",";
            }
            if (ids.Length > 0)
            {
                ids = ids.Remove(ids.Length - 1);
                return BooksPageDal.SelectForIDS(ids);
            }
            else
            {
                return new List<Books>();
            }
        }
        public static List<View_Books> SelectBookPage(BooksSelect info)
        {
            info.TableName = "View_Books";
            info.KeyName = "BookID";
            info.Filter = "BookID,BLName,BSName,BookTitle,BookPublish,BookMoney,BookPrice,BookSale,BookDeport,BookIsBuy,BookIsHot,BSID,BookAuthor,ISBN,BookDesc";
            info.Order = " BookID desc ";
            info.Where = " 1=1 ";
            if (!string.IsNullOrEmpty(info.BookTitle))
            {
                info.Where += " and BookTitle like '%" + info.BookTitle + "%'";
            }
            if (!string.IsNullOrEmpty(info.BookPublish))
            {
                info.Where += " and BookPublish like '%" + info.BookPublish + "%'";
            }
            if (info.BLID > -1)
            {
                info.Where += " and BLID=" + info.BLID;
            }
            if (info.BSID > -1)
            {
                info.Where += " and BSID=" + info.BSID;
            }
            if (info.BookIsHot > -1)
            {
                info.Where += " and BookIsHot=" + info.BookIsHot;
            }
            if (info.BookIsBuy > -1)
            {
                info.Where += " and BookIsBuy=" + info.BookIsBuy;
            }
            return BooksPageDal.SelectBookPage(info);
        }
        public static bool Deleter(int BookID)
        {
            int a = BooksPageDal.Deleter(BookID);
            return a > 0;
        }
        public static bool Insert(Books info) 
        {
            int a = BooksPageDal.Insert(info);
            return a > 0;
        }
        public static bool Update(Books info)
        {
            int a = BooksPageDal.Update(info);
            return a > 0;
        }
    }
}
