using BookModel;
using BooksModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDal
{
    public class OrderPageDal
    {
        public static int Insert(Orders info)
        {
            string sqlstr = "insert into Orders(UserID,AMID,OrderNum,OrderMoney) values(@UserID,@AMID,@OrderNum,@OrderMoney);select @@identity";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMID", info.AMID));
            list.Add(new SqlParameter("@OrderNum", info.OrderNum));
            list.Add(new SqlParameter("@OrderMoney", info.OrderMoney));
            return int.Parse(SqlHelp.SelectSingle(sqlstr, list).ToString());
        }
        public static int Update(Orders info)
        {
            string sqlstr = "Update Orders Set UserID = @UserID,AMID = @AMID,OrderNum = @OrderNum,OrderDate = @OrderDate,OrderState = @OrderState,OrderMoney = @OrderMoney Where OrderID = @OrderID;";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMID", info.AMID));
            list.Add(new SqlParameter("@OrderNum", info.OrderNum));
            list.Add(new SqlParameter("@OrderDate", info.OrderDate));
            list.Add(new SqlParameter("@OrderState", info.OrderState));
            list.Add(new SqlParameter("@OrderMoney", info.OrderMoney));
            list.Add(new SqlParameter("@OrderID", info.OrderID));
            return SqlHelp.CUD(sqlstr, list);
        }
        public static List<Orders> SeletAll()
        {
            string sqlstr = "select OrderID,UserNick,OrderNum,OrderDate,OrderState,OrderMoney from Orders,Users where Orders.UserID=Users.UserID";
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                List<Orders> list = new List<Orders>();
                while (r.Read())
                {
                    Orders info = new Orders();
                    info.OrderID = (int)r["OrderID"];
                    info.UserNick = r["UserNick"].ToString();
                    info.OrderNum = r["OrderNum"].ToString();
                    info.OrderDate = (DateTime)r["OrderDate"];
                    info.OrderState = (int)r["OrderState"];
                    info.OrderMoney = (decimal)r["OrderMoney"];
                    list.Add(info);
                }
                return list;
            }
        }
        public static Orders SeletAllByID(int OrderID)
        {
            string sqlstr = $"select OrderID,AMID,Orders.UserID,UserNick,OrderNum,OrderDate,OrderState,OrderMoney from Orders,Users where Orders.UserID=Users.UserID and OrderID={OrderID}";
            Orders info = new Orders();
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                while (r.Read())
                {
                    info.OrderID = (int)r["OrderID"];
                    info.AMID = (int)r["AMID"];
                    info.UserID = (int)r["UserID"];
                    info.UserNick = r["UserNick"].ToString();
                    info.OrderNum = r["OrderNum"].ToString();
                    info.OrderDate = (DateTime)r["OrderDate"];
                    info.OrderState = (int)r["OrderState"];
                    info.OrderMoney = (decimal)r["OrderMoney"];
                }
                return info;
            }
        }
        public static View_Orders SelectByID(int OrderID)
        {
            string sqlstr = $"select * from view_orders where OrderID={OrderID}";
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                View_Orders info = new View_Orders();
                //读取数据
                while (read.Read())
                {
                    info.OrderID = (int)read["OrderID"];
                    info.UserNick = read["UserNick"].ToString();
                    info.OrderNum = read["OrderNum"].ToString();
                    info.UserName = read["UserName"].ToString();
                    info.OrderState = (int)read["OrderState"];
                    info.OrderDate = (DateTime)read["OrderDate"];
                    info.OrderMoney = (decimal)read["OrderMoney"];
                    info.AMAddress = read["AMAddress"].ToString();
                    info.AMTel = read["AMTel"].ToString();
                    info.AMUser = read["AMUser"].ToString();
                }
                return info;
            }
        }
        public static List<View_Orders> SelectBookPage(proc_page pinfo)
        {
            List<View_Orders> list = new List<View_Orders>();
            //用于获取输出参数
            SqlParameter p = new SqlParameter();
            using (SqlDataReader read = SqlHelp.ExecuteProcPage(pinfo, p))
            {
                //读取数据
                while (read.Read())
                {
                    View_Orders info = new View_Orders();
                    info.OrderID = (int)read["OrderID"];
                    info.UserNick = read["UserNick"].ToString();
                    info.UserName = read["UserName"].ToString();
                    info.OrderNum = read["OrderNum"].ToString();
                    info.OrderState = (int)read["OrderState"];
                    info.OrderDate = (DateTime)read["OrderDate"];
                    info.OrderMoney = (decimal)read["OrderMoney"];
                    info.AMAddress = read["AMAddress"].ToString();
                    info.AMTel = read["AMTel"].ToString();
                    info.AMUser = read["AMUser"].ToString();
                    list.Add(info);
                }
            }
            pinfo.DataCount = (int)p.Value;
            return list;
        }
    }
}
