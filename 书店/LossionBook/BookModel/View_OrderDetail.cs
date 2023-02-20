using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksModel
{
    [Key("ODID")]
    public class View_OrderDetail:ModelBase
    {
        public System.Int32? ODID { get; set; }
        public System.Int32? bookid { get; set; }
        public System.Decimal? ODPrice { get; set; }
        public System.Int32? ODCount { get; set; }
        public System.Int32? BAID { get; set; }
        public System.String ISBN { get; set; }
        public System.Int32? UserID { get; set; }
        public System.Int32? OrderState { get; set; }
        public System.String BookTitle { get; set; }
        public System.Int32? BookID { get; set; }
        public System.Int32? OrderID { get; set; }
    }
}