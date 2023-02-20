using BookModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDal
{
    public class OrderDetailDal
    {
        public static int Insert(OrderDetail info)
        {
            string sql = "insert into OrderDetail(OrderID,BookID,ODPrice,ODCount,ODMoney) values(@OrderID,@BookID,@ODPrice,@ODCount,@ODMoney)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@OrderID", info.OrderID));
            list.Add(new SqlParameter("@BookID", info.BookID));
            list.Add(new SqlParameter("@ODPrice", info.ODPrice));
            list.Add(new SqlParameter("@ODCount", info.ODCount));
            list.Add(new SqlParameter("@ODMoney", info.ODMoney));
            return SqlHelp.CUD(sql, list);
        }
        public static List<OrderDetail> SelectAll(int OrderID)
        {
            string sqlstr = $"select ODID,OrderID,OrderDetail.BookID,BookTitle,ODPrice,ODCount,ODMoney from OrderDetail,Books where OrderDetail.BookID=Books.BookID and OrderID={OrderID}";
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                List<OrderDetail> list = new List<OrderDetail>();
                //读取数据
                while (read.Read())
                {
                    OrderDetail info = new OrderDetail();
                    info.ODID = (int)read["ODID"];
                    info.OrderID = (int)read["OrderID"];
                    info.BookID = (int)read["BookID"];
                    info.BookTitle = read["BookTitle"].ToString();
                    info.ODPrice = (decimal)read["ODPrice"];
                    info.ODCount = (int)read["ODCount"];
                    info.ODMoney = (decimal)read["ODMoney"];
                    list.Add(info);
                }
                return list;
            }
        }
    }
}
