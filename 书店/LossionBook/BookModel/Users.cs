using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksModel
{
    [Key("UserID")]
    public class Users:ModelBase
    {
        public System.Int32? UserID { get; set; }
        public System.String UserName { get; set; }
        public System.String UserPwd { get; set; }
        public System.String UserEmail { get; set; }
        public System.String UserSex { get; set; }
        public System.String UserNick { get; set; }
    }
}