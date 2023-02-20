using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Serializable]
    public class OrdersSelect:proc_page
    {
        private string orderNum = "";
        private string userName = "";
        private int orderState = -1;
        private string orderDateStart = "";
        private string orderDateEnd = "";
        private string userNick = "";
        public string OrderNum { get => orderNum; set => orderNum = value; }
        public string UserName { get => userName; set => userName = value; }
        public int OrderState { get => orderState; set => orderState = value; }
        public string OrderDateStart { get => orderDateStart; set => orderDateStart = value; }
        public string OrderDateEnd { get => orderDateEnd; set => orderDateEnd = value; }
        public string UserNick { get => userNick; set => userNick = value; }
    }
}
