using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookModel;

namespace BookDal
{
    public class BLCategoryPageDal
    {
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static List<BLCategory> SeletAll() 
        {
            string sqlstr = "select BLID,BLName from  BLCategory";
            using (SqlDataReader read=SqlHelp.SelectReader(sqlstr))
            {
                List<BLCategory> list = new List<BLCategory>();
                while (read.Read()) 
                {
                    BLCategory info = new BLCategory();
                    //info.BLID = (System.Int32)read["BLID"];
                    //info.BLName = (System.String)read["BLName"];
                    info.BLID = (int)read["BLID"];
                    info.BLName = read["BLName"].ToString();
                    list.Add(info);
                }
                return list;
            }
        }
        public static List<BLCategory> SeletAll(int BLID)
        {
            string sqlstr = "select BLID,BLName from  BLCategory where 1=1";
            if (BLID!=0) 
            {
                sqlstr += $" and BLID={BLID}";
            }
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                List<BLCategory> list = new List<BLCategory>();
                while (read.Read())
                {
                    BLCategory info = new BLCategory();
                    //info.BLID = (System.Int32)read["BLID"];
                    //info.BLName = (System.String)read["BLName"];
                    info.BLID = (int)read["BLID"];
                    info.BLName = read["BLName"].ToString();
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="BLID"></param>
        /// <returns>返回数据集</returns>
        public static BLCategory SeletByID(string BLID)
        {
            string sqlstr = $"select BLID,BLName from  BLCategory where BLID={BLID}";
            BLCategory info = new BLCategory();
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                while (r.Read())
                {
                    info.BLID = (int)r["BLID"];
                    info.BLName = r["BLName"].ToString();
                } 
                return info;
            }
        }
        /// <summary>
        /// 删除大类别
        /// </summary>
        /// <param name="BLID"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Deleter(int BLID)
        {
            string sqlstr = "Delete From BLCategory Where BLID=@BLID";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("BLID", BLID));
            return SqlHelp.CUD(sqlstr,list);
        }
        /// <summary>
        /// 添加大类别
        /// </summary>
        /// <param name="info"></param>
        /// <returns>返回受影响的行数</returns>
        public static int Insert(BLCategory info)
        {
            string sqlstr = $"insert into BLCategory(BLName) values('{info.BLName}')" ;
            return SqlHelp.CUD(sqlstr);
        }
        /// <summary>
        /// 编辑大类别
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public static int Update(BLCategory info)
        {
            string sqlstr = $"update BLCategory set BLName='{info.BLName}' where BLID={info.BLID}";
            return SqlHelp.CUD(sqlstr);
        }
    }
}
