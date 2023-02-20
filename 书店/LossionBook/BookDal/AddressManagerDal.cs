using BooKModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDal
{
    public class AddressManagerDal
    {
        public static List<AddressManager> SelectAll()
        {
            string sqlstr = "select AMID,UserID,AMUser,AMTel,AMAddress,AMMark from AddressManager";
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                List<AddressManager> list = new List<AddressManager>();
                while (read.Read())
                {
                    AddressManager info = new AddressManager();
                    info.AMID = (int)read["AMID"];
                    info.UserID = (int)read["UserID"];
                    info.AMUser = read["AMUser"].ToString();
                    info.AMTel = read["AMTel"].ToString();
                    info.AMAddress = read["AMAddress"].ToString();
                    info.AMMark = (bool)read["AMMark"];
                    list.Add(info);
                }
                return list;
            }
        }
        public static AddressManager SelectForID(int id)
        {
            string sqlstr = "select AMID,UserID,AMUser,AMTel,AMAddress,AMMark from AddressManager where AMID = @AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AMID", id));
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr, list))
            {
                AddressManager info = null;
                if (read.Read())
                {
                    info = new AddressManager();
                    info.AMID = (System.Int32)read["AMID"];
                    info.UserID = (System.Int32)read["UserID"];
                    info.AMUser = (System.String)read["AMUser"];
                    info.AMTel = (System.String)read["AMTel"];
                    info.AMAddress = (System.String)read["AMAddress"];
                    info.AMMark = (System.Boolean)read["AMMark"];
                }
                return info;
            }
        }
        /// <summary>
        /// 根据UserID查找地址表中第一条数据的值
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static AddressManager SelectForDefault(int userID)
        {
            string sqlstr = "select AMID,UserID,AMUser,AMTel,AMAddress from AddressManager where AMMark=1 and UserID=" + userID;
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                AddressManager info = null;
                if (read.Read())
                {
                    info = new AddressManager();
                    info.AMID = (System.Int32)read["AMID"];
                    info.UserID = (System.Int32)read["UserID"];
                    info.AMUser = (System.String)read["AMUser"];
                    info.AMTel = (System.String)read["AMTel"];
                    info.AMAddress = (System.String)read["AMAddress"];
                }
                return info;
            }
        }
        /// <summary>
        /// 根据UserID查找地址表中对应的值
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<AddressManager> SelectForUser(int userID)
        {
            string sqlString = "select AMID,UserID,AMUser,AMTel,AMAddress,AMMark from AddressManager where UserID=" + userID;
            using (SqlDataReader read = SqlHelp.SelectReader(sqlString))
            {
                List<AddressManager> list = new List<AddressManager>();
                while (read.Read())
                {
                    AddressManager info = new AddressManager();
                    info.AMID = (System.Int32)read["AMID"];
                    info.UserID = (System.Int32)read["UserID"];
                    info.AMUser = (System.String)read["AMUser"];
                    info.AMTel = (System.String)read["AMTel"];
                    info.AMAddress = (System.String)read["AMAddress"];
                    info.AMMark = (System.Boolean)read["AMMark"];
                    list.Add(info);
                }
                return list;
            }
        }
        public static void DeleteDefault(int userID)
        {
            string sql = "update AddressManager set AMMark=0 where AMMark=1 and UserID=" + userID;
            SqlHelp.CUD(sql);
        }
        public static void SetDefault(int userID, int addID)
        {
            string sql = "update AddressManager set AMMark=1 where AMID=" + addID + " and UserID=" + userID;
            SqlHelp.CUD(sql);
        }
        public static int Insert(AddressManager info)
        {
            string sql = "insert into AddressManager(UserID,AMUser,AMTel,AMAddress,AMMark) values(@UserID,@AMUser,@AMTel,@AMAddress,@AMMark);select @@identity";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMUser", info.AMUser));
            list.Add(new SqlParameter("@AMTel", info.AMTel));
            list.Add(new SqlParameter("@AMAddress", info.AMAddress));
            list.Add(new SqlParameter("@AMMark", info.AMMark));
            return int.Parse(SqlHelp.SelectSingle(sql, list).ToString());
        }
        public static int Update(AddressManager info)
        {
            string sql = "update AddressManager set UserID = @UserID ,AMUser = @AMUser ,AMTel = @AMTel ,AMAddress = @AMAddress ,AMMark = @AMMark   where AMID = @AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@UserID", info.UserID));
            list.Add(new SqlParameter("@AMUser", info.AMUser));
            list.Add(new SqlParameter("@AMTel", info.AMTel));
            list.Add(new SqlParameter("@AMAddress", info.AMAddress));
            list.Add(new SqlParameter("@AMMark", info.AMMark));
            list.Add(new SqlParameter("@AMID", info.AMID));
            return SqlHelp.CUD(sql, list);
        }
        public static int Delete(int id)
        {
            string sql = "delete AddressManager where AMID=@AMID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@AMID", id));
            return SqlHelp.CUD(sql, list);
        }
    }
}
