using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("BookID")]
    public class Books:ModelBase
    {
        public System.Int32? BookID { get; set; }
        public System.Int32? BSID { get; set; }
        public System.String BLName { get; set; }
        public System.String BSName { get; set; }
        public System.String BookTitle { get; set; }
        public System.String BookAuthor { get; set; }
        public System.String BookPublish { get; set; }
        public System.String ISBN { get; set; }
        public System.Int32? BookCount { get; set; }
        public System.Decimal? BookMoney { get; set; }
        public System.Decimal? BookPrice { get; set; }
        public System.String BookDesc { get; set; }
        public System.String BookAuthorDesc { get; set; }
        public System.String BookComm { get; set; }
        public System.String BookContent { get; set; }
        public System.Int32? BookSale { get; set; }
        public System.Int32? BookDeport { get; set; }
        public System.Boolean? BookIsBuy { get; set; }
        public System.Boolean? BookIsHot { get; set; }
        public System.Boolean? BookIsDelete { get; set; }
        public System.DateTime? BookBuyDate { get; set; }
        public System.DateTime? BookHotDate { get; set; }
        public int BLID { get; set; }
    }
}