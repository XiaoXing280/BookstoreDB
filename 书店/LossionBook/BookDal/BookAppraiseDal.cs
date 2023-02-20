using BookModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDal
{
    public class BookAppraiseDal
    {
        public static List<BookAppraise> GetModelListBySqlStr(int BookID)
        {
            string sql = $@"select UserNick,BADate,BAPoint,BADesc,BookID from Orders,OrderDetail,BookAppraise,Users 
                                where BookAppraise.ODID=OrderDetail.ODID and Users.UserID=Orders.UserID 
                                and Orders.OrderID=OrderDetail.OrderID and OrderDetail.BookID={BookID}";
            using (SqlDataReader read = SqlHelp.SelectReader(sql))
            {
                List<BookAppraise> list = new List<BookAppraise>();
                while (read.Read())
                {
                    BookAppraise info = new BookAppraise();
                    info.UserNick = read["UserNick"].ToString();
                    info.BADate =(DateTime)read["BADate"];
                    info.BAPoint = (int)read["BAPoint"];
                    info.BADesc = read["BADesc"].ToString();
                    info.BookID = (int)read["BookID"];
                    list.Add(info);
                }
                return list;
            }
        }
    }
}
