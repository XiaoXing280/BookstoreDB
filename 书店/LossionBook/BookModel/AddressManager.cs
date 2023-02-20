using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooKModel
{
    [Key("AMID")]
    public class AddressManager:ModelBase
    {
        public System.Int32? AMID { get; set; }
        public System.Int32? UserID { get; set; }
        public System.String AMUser { get; set; }
        public System.String AMTel { get; set; }
        public System.String AMAddress { get; set; }
        public System.Boolean? AMMark { get; set; }
    }
}