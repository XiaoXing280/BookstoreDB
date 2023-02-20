using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksModel
{
    [Key("BSID")]
    public class View_BSCategory:ModelBase
    {
        public System.Int32? BSID { get; set; }
        public System.String BSName { get; set; }
        public System.Int32? BLID { get; set; }
        public System.String BLName { get; set; }
    }
}