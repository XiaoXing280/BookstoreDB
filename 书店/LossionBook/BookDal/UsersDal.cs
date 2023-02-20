using BooksModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDal
{
    public class UsersDal
    {
        public static Users login(string UserName,string UserPwd)
        {
            string sqlstr = $"select UserID,UserName,UserNick from Users where UserName='{UserName}' and UserPwd='{UserPwd}'";
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                Users info = null;
                if (read.Read())
                {
                    info = new Users();
                    info.UserID = (System.Int32)read["UserID"];
                    info.UserName = (System.String)read["UserName"];
                    info.UserNick = (System.String)read["UserNick"];
                }
                return info;
            }
        }
        public static int Insert(Users info)
        {
            string sqlstr = $"insert into Users(UserName,UserPwd,UserEmail,UserSex,UserNick) values('{info.UserName}', '{info.UserPwd}', '{info.UserEmail}', '{info.UserSex}', '{info.UserNick}')";
            return SqlHelp.CUD(sqlstr);
        }

    }
}
