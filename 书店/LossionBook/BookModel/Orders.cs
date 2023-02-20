using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("OrderID")]
    public class Orders:ModelBase
    {
        public System.Int32? OrderID { get; set; }
        public System.Int32? UserID { get; set; }
        public System.Int32? AMID { get; set; }
        public System.String OrderNum { get; set; }
        public System.DateTime? OrderDate { get; set; }
        public System.Int32? OrderState { get; set; }
        public System.Decimal? OrderMoney { get; set; }
        public string UserNick { get; set; }
    }
}