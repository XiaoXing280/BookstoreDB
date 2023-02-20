using BookDal;
using BookModel;
using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BookBll
{
    public class OrderPageBll
    {
        public static bool Insert(Orders info) 
        {
            int rows = OrderPageDal.Insert(info);
            return rows > 0;
        }
        public static bool Update(Orders info)
        {
            int rows = OrderPageDal.Update(info);
            return rows > 0;
        }
        public static List<Orders> SeletAll() 
        {
            return OrderPageDal.SeletAll();
        }
        public static Orders SeletAllByID(int OrderID) 
        {
            return OrderPageDal.SeletAllByID(OrderID);
        }
        public static View_Orders SelectByID(int OrderID) 
        {
            return OrderPageDal.SelectByID(OrderID);
        }
        public static List<View_Orders> SelectBookPage(OrdersSelect info)
        {
            info.TableName = "view_orders";
            info.KeyName = "OrderID";
            info.Filter = "OrderID,OrderNum,UserNick,UserName,OrderMoney,OrderState,OrderDate,AMTel,AMUser,AMAddress";
            info.Order = " OrderID desc ";
            info.Where = " 1=1 ";
            if (!string.IsNullOrEmpty(info.OrderNum))
            { info.Where += $" and OrderNum like '%{info.OrderNum}%' "; }
            if (!string.IsNullOrEmpty(info.UserNick))
            { info.Where += $" and UserNick like '%{info.UserNick}%' "; }
            if (info.OrderState>0) 
            {
                info.Where += $" and OrderState={info.OrderState}";
            }
            if (!string.IsNullOrEmpty(info.OrderDateStart)&& !string.IsNullOrEmpty(info.OrderDateEnd)&&(info.OrderDateStart== "yyyy/mm/日"|| info.OrderDateEnd == "yyyy/mm/日"))
            {
                info.Where +=string.Format($" and  OrderDate>'{info.OrderDateStart}' and OrderDate<'{info.OrderDateEnd}'");
            }
            return OrderPageDal.SelectBookPage(info);
        }

        public static string CreateOrder(Orders info, Dictionary<int, int> dic)
        {
            //生成订单编号：调用自定义函数
            info.OrderNum = SqlHelp.SelectSingle("select dbo.BuildNum()").ToString();
            //根据购物车信息查询书籍信息
            List<Books> listBook = BooksPageBll.SelectForIDS(dic);
            //根据书籍信息创建订单详单集合
            List<OrderDetail> listDeta = new List<OrderDetail>();
            decimal sum = 0;
            foreach (Books item in listBook)
            {
                OrderDetail detaInfo = new OrderDetail();
                detaInfo.BookID = item.BookID;
                detaInfo.ODPrice = item.BookMoney;
                detaInfo.ODCount = dic[(int)detaInfo.BookID];
                detaInfo.ODMoney = detaInfo.ODPrice * detaInfo.ODCount;
                listDeta.Add(detaInfo);
                sum += (decimal)detaInfo.ODMoney;
            }
            info.OrderMoney = sum;

            //开启事务，先添加1条订单信息，再添加多条订单详单信息
            using (TransactionScope tr = new TransactionScope())
            {
                //添加订单并获取订单ID
                int id = OrderPageDal.Insert(info);
                foreach (var item in listDeta)
                {
                    item.OrderID = id;
                    OrderDetailDal.Insert(item);
                }
                tr.Complete();
            }

            return info.OrderNum;
        }
    }
}
