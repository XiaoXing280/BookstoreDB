using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookModel
{
    [Key("AdminID")]
    public class Admins:ModelBase
    {
        public System.Int32? AdminID { get; set; }
        public System.String AdminUser { get; set; }
        public System.String AdminPwd { get; set; }
    }
}