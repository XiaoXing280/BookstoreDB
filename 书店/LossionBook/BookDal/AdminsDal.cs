using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookModel;
using System.Data;
using System.Data.SqlClient;

namespace BookDal
{
    public class AdminsDal
    {
        public static int login(Admins info) 
        {
            string sqlstr = $"select  count(*) from Admins where AdminUser='{info.AdminUser}' and AdminPwd='{info.AdminPwd}'";
            int res = Convert.ToInt32(SqlHelp.SelectSingle(sqlstr));
            return res;
        }
    }
}
