using BookDal;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class OrderDetailBll
    {
        public static bool Insert(OrderDetail info) 
        {
            int rows = OrderDetailDal.Insert(info);
            return rows > 0;
        }
        public static List<OrderDetail> SelectAll(int OrderID)
        {
            return OrderDetailDal.SelectAll(OrderID);
        }
    }
}
