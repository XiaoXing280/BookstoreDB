using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("BLID")]
    public class BLCategory:ModelBase
    {
        public System.Int32? BLID { get; set; }
        public System.String BLName { get; set; }
    }
}