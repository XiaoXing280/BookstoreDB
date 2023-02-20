using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("ODID")]
    public class OrderDetail:ModelBase
    {
        public System.Int32? ODID { get; set; }
        public System.Int32? OrderID { get; set; }
        public System.Int32? BookID { get; set; }
        public System.String BookTitle { get; set; }
        public System.Decimal? ODPrice { get; set; }
        public System.Int32? ODCount { get; set; }
        public System.Decimal? ODMoney { get; set; }
    }
}