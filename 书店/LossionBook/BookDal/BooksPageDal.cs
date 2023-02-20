using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookModel;
using System.Data;
using System.Data.SqlClient;
using BooksModel;

namespace BookDal
{
    public class BooksPageDal
    {
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static List<Books> SeletAll()
        {
            string sqlstr = @"select BookID,BSName,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,
                              BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot, BookIsDelete,
                              BookBuyDate,BookHotDate from Books,BsCategory where Books.BSID = BsCategory.BSID";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Books> list = new List<Books>();
                while (r.Read())
                {
                    Books info = new Books();
                    info.BookID = (int)r["BookID"];
                    info.BSName = r["BSName"].ToString();
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (System.Int32)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                    //info.BookBuyDate = (DateTime)r["BookBuyDate"];
                    //info.BookHotDate = (DateTime)r["BookHotDate"];
                    list.Add(info);
                }
                return list;
            }
        }
        public static List<Books> SeletAllBookID(int BookID)
        {
            string sqlstr = $@"select BookID,BSName,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,
                              BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot, BookIsDelete,
                              BookBuyDate,BookHotDate from Books,BsCategory where Books.BSID = BsCategory.BSID and BookID={BookID}";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Books> list = new List<Books>();
                while (r.Read())
                {
                    Books info = new Books();
                    info.BookID = (int)r["BookID"];
                    info.BSName = r["BSName"].ToString();
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (System.Int32)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 根据ID查值
        /// </summary>
        /// <returns></returns>
        public static Books SeletAllByID(int BookID)
        {
            string sqlstr = "select BookID,BLCategory.BLID,BsCategory.BSID,BSName,BLName,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc," +
                            "BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot, BookIsDelete,"+
                            "BookBuyDate,BookHotDate from Books,BsCategory,BLCategory where Books.BSID = BsCategory.BSID and BsCategory.BLID=BLCategory.BLID " +
                            $"and BookID ={BookID}";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                Books info = new Books();
                while (r.Read())
                {
                    info.BookID = (int)r["BookID"];
                    info.BLID = (int)r["BLID"];
                    info.BSID = (int)r["BSID"];
                    info.BSName = r["BSName"].ToString();
                    info.BLName = r["BLName"].ToString();
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (int)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                }
                return info;
            }
        }
        /// <summary>
        /// 根据是否热销前端查询前五条数据
        /// </summary>
        /// <param name="BookID"></param>
        /// <returns></returns>
        public static List<Books> SeletAllByISBuy() 
        {
            string sqlstr = $"select top 5 * from Books where BookIsBuy=1 order by BookID";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Books> list = new List<Books>();
                while (r.Read())
                {
                    Books info = new Books();
                    info.BookID = (int)r["BookID"];
                    info.BSID = (int)r["BSID"];
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (int)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 对前端订单的查询
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public static List<Books> SelectForIDS(string ids)
        {
            string sql = "select BookID,BookTitle,BookMoney,BookPrice from Books where BookID in (" + ids + ")";
            using (SqlDataReader read = SqlHelp.SelectReader(sql))
            {
                List<Books> list = new List<Books>();
                while (read.Read())
                {
                    Books info = new Books();
                    info.BookID = (System.Int32)read["BookID"];
                    info.BookTitle = (System.String)read["BookTitle"];
                    info.BookMoney = (System.Decimal)read["BookMoney"];
                    info.BookPrice = (System.Decimal)read["BookPrice"];
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 根据是否热门前端查询前十条数据
        /// </summary>
        /// <returns></returns>
        public static List<Books> SeletAllByISHot() 
        {
            string sqlstr = $"select top 10 * from Books where BookIsHot=1 order by BookID";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Books> list = new List<Books>();
                while (r.Read())
                {
                    Books info = new Books();
                    info.BookID = (int)r["BookID"];
                    info.BSID = (int)r["BSID"];
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (int)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 按照销售数量排行，找前五条数据
        /// </summary>
        /// <returns></returns>
        public static List<Books> SeletAllByBookSale() 
        {
            string sqlstr = $"select top 5 * from Books  order by BookSale";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Books> list = new List<Books>();
                while (r.Read())
                {
                    Books info = new Books();
                    info.BookID = (int)r["BookID"];
                    info.BSID = (int)r["BSID"];
                    info.BookTitle = r["BookTitle"].ToString();
                    info.BookAuthor = (System.String)r["BookAuthor"];
                    info.BookPublish = (System.String)r["BookPublish"];
                    info.ISBN = (System.String)r["ISBN"];
                    info.BookCount = (int)r["BookCount"];
                    info.BookMoney = (decimal)r["BookMoney"];
                    info.BookPrice = (decimal)r["BookPrice"];
                    info.BookDesc = r["BookDesc"].ToString();
                    info.BookAuthorDesc = r["BookAuthorDesc"].ToString();
                    info.BookComm = r["BookComm"].ToString();
                    info.BookContent = r["BookContent"].ToString();
                    info.BookSale = (int)r["BookSale"];
                    info.BookDeport = (int)r["BookDeport"];
                    info.BookIsBuy = (bool)r["BookIsBuy"];
                    info.BookIsHot = (bool)r["BookIsHot"];
                    info.BookIsDelete = (bool)r["BookIsDelete"];
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pinfo"></param>
        /// <returns></returns>
        public static List<View_Books> SelectBookPage(proc_page pinfo)
        {
            List<View_Books> list = new List<View_Books>();
            //用于获取输出参数
            SqlParameter p = new SqlParameter();
            using (SqlDataReader read = SqlHelp.ExecuteProcPage(pinfo, p))
            {
                //读取数据
                while (read.Read())
                {
                    View_Books info = new View_Books();
                    info.BookID = (System.Int32)read["BookID"];
                    info.BSID = (System.Int32)read["BSID"];
                    info.BookTitle = (System.String)read["BookTitle"];
                    info.BookAuthor = (System.String)read["BookAuthor"];
                    info.BookPublish = (System.String)read["BookPublish"];
                    info.ISBN = (System.String)read["ISBN"];
                    info.BookMoney = (System.Decimal)read["BookMoney"];
                    info.BookPrice = (System.Decimal)read["BookPrice"];
                    info.BookSale = (System.Int32)read["BookSale"];
                    info.BookDeport = (System.Int32)read["BookDeport"];
                    info.BookIsBuy = (System.Boolean)read["BookIsBuy"];
                    info.BookIsHot = (System.Boolean)read["BookIsHot"];
                    info.BSName = (string)read["BSName"];
                    info.BLName = (string)read["BLName"];
                    info.BookDesc = read["BookDesc"].ToString();
                    list.Add(info);
                }

            }
            pinfo.DataCount = (int)p.Value;
            return list;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="BLID"></param>
        /// <returns></returns>
        public static int Deleter(int BookID)
        {
            string sqlstr = "delete from Books where BookID=@BookID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("BookID", BookID));
            return SqlHelp.CUD(sqlstr, list);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int Insert(Books info) 
        {
            string sqlstr = $"insert into Books(BSID,BookTitle,BookAuthor,BookPublish,ISBN,BookCount,BookMoney,BookPrice,BookDesc,BookAuthorDesc,BookComm,BookContent,BookSale,BookDeport,BookIsBuy,BookIsHot, BookIsDelete) "+
                             $"values(@BSID,@BookTitle,@BookAuthor,@BookPublish,@ISBN,@BookCount,@BookMoney,@BookPrice,@BookDesc,@BookAuthorDesc,@BookComm,@BookContent,@BookSale,@BookDeport,@BookIsBuy,@BookIsHot,@BookIsDelete)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BSID", info.BSID));
            list.Add(new SqlParameter("@BookTitle", info.BookTitle));
            list.Add(new SqlParameter("@BookAuthor", info.BookAuthor));
            list.Add(new SqlParameter("@BookPublish", info.BookPublish));
            list.Add(new SqlParameter("@ISBN", info.ISBN));
            list.Add(new SqlParameter("@BookCount", info.BookCount));
            list.Add(new SqlParameter("@BookMoney", info.BookMoney));
            list.Add(new SqlParameter("@BookPrice", info.BookPrice));
            list.Add(new SqlParameter("@BookDesc", info.BookDesc));
            list.Add(new SqlParameter("@BookAuthorDesc", info.BookAuthorDesc));
            list.Add(new SqlParameter("@BookComm", info.BookComm));
            list.Add(new SqlParameter("@BookContent", info.BookContent));
            list.Add(new SqlParameter("@BookSale", info.BookSale));
            list.Add(new SqlParameter("@BookDeport", info.BookDeport));
            list.Add(new SqlParameter("@BookIsBuy", info.BookIsBuy));
            list.Add(new SqlParameter("@BookIsHot", info.BookIsHot));
            list.Add(new SqlParameter("@BookIsDelete", info.BookIsDelete));
            return SqlHelp.CUD(sqlstr, list);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int Update(Books info) 
        {
            string sqlstr = "update Books set BSID = @BSID ,BookTitle = @BookTitle ,BookAuthor = @BookAuthor ,BookPublish = @BookPublish ," +
                "ISBN = @ISBN ,BookCount = @BookCount ,BookMoney = @BookMoney ,BookPrice = @BookPrice ,BookDesc = @BookDesc ," +
                "BookAuthorDesc = @BookAuthorDesc ,BookComm = @BookComm ,BookContent = @BookContent where BookID = @BookID ";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@BookID", info.BookID));
            list.Add(new SqlParameter("@BSID", info.BSID));
            list.Add(new SqlParameter("@BookTitle", info.BookTitle));
            list.Add(new SqlParameter("@BookAuthor", info.BookAuthor));
            list.Add(new SqlParameter("@BookPublish", info.BookPublish));
            list.Add(new SqlParameter("@ISBN", info.ISBN));
            list.Add(new SqlParameter("@BookCount", info.BookCount));
            list.Add(new SqlParameter("@BookMoney", info.BookMoney));
            list.Add(new SqlParameter("@BookPrice", info.BookPrice));
            list.Add(new SqlParameter("@BookDesc", info.BookDesc));
            list.Add(new SqlParameter("@BookAuthorDesc", info.BookAuthorDesc));
            list.Add(new SqlParameter("@BookComm", info.BookComm));
            list.Add(new SqlParameter("@BookContent", info.BookContent));
            return SqlHelp.CUD(sqlstr, list);
        }


    }
}
