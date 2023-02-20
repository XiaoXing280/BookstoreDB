using BookDal;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class AdminsBll
    {
        public static bool login(Admins info) 
        {
            info.AdminPwd = MD5Service.GetMD5CodeToString(info.AdminPwd);
            int r= AdminsDal.login(info);
            return r > 0;
        }
    }
}
