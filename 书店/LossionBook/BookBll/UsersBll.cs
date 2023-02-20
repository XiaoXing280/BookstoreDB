using BookDal;
using BooksModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class UsersBll
    {
        public static Users login(string UserName, string UserPwd)
        {
            return UsersDal.login(UserName,UserPwd);
        }
        public static bool Insert(Users info)
        {
            int a= UsersDal.Insert(info);
            return a>0;
        }
    }
}
