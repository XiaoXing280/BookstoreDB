using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("BAID")]
    public class BookAppraise:ModelBase
    {
        public System.Int32? BAID { get; set; }
        public System.Int32? ODID { get; set; }
        public System.String BADesc { get; set; }
        public System.Int32? BAPoint { get; set; }
        public System.DateTime? BADate { get; set; }
        public int BookID { get; set; }
        public string UserNick { get; set; }
    }
}