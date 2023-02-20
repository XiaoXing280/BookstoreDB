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
    public class BSCategoryPageDal
    {
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="BLID"></param>
        /// <returns></returns>
        public static List<BSCategory> SeletAll(int BLID)
        {
            string sqlstr = "select BSID,BLName,BSName from  BsCategory,BLCategory where BsCategory.BLID=BLCategory.BLID ";
            if (BLID!=0) 
            {
                sqlstr += $" and BsCategory.BLID={BLID}";
            }
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                List<BSCategory> list = new List<BSCategory>();
                //读取数据
                while (read.Read())
                {
                    BSCategory info = new BSCategory();
                    //info.BLID = (System.Int32)read["BLID"];
                    //info.BLName = (System.String)read["BLName"];
                    info.BSID = (System.Int32)read["BSID"];
                    info.BLName = read["BLName"].ToString();
                    info.BSName = read["BSName"].ToString();
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        public static List<BSCategory> SeletAll()
        {
            string sqlstr = "select BSID,BLName,BSName from  BsCategory,BLCategory where BsCategory.BLID=BLCategory.BLID";
            using (SqlDataReader read = SqlHelp.SelectReader(sqlstr))
            {
                List<BSCategory> list = new List<BSCategory>();
                while (read.Read())
                {
                    BSCategory info = new BSCategory();
                    //info.BLID = (System.Int32)read["BLID"];
                    //info.BLName = (System.String)read["BLName"];
                    info.BSID = (System.Int32)read["BSID"];
                    info.BLName = read["BLName"].ToString();
                    info.BSName = read["BSName"].ToString();
                    list.Add(info);
                }
                return list;
            }
        }
        /// <summary>
        /// 根据ID查询数据
        /// </summary>
        /// <param name="BSID"></param>
        /// <returns></returns>
        public static BSCategory SeletByID(string BSID)
        {
            string sqlstr = $"select BSID,BLID,BSName from  BsCategory where BSID={BSID}";
            BSCategory info = new BSCategory();
            using (SqlDataReader r = SqlHelp.SelectReader(sqlstr))
            {
                while (r.Read())
                {
                    info.BLID = (int)r["BLID"];
                    info.BSID = (System.Int32)r["BSID"];
                    info.BSName = r["BSName"].ToString();
                }
                return info;
            }
        }
        public static int Deleter(int BSID)
        {
            string sqlstr = "Delete From BsCategory Where BSID=" + BSID;
            return SqlHelp.CUD(sqlstr);
        }
        public static int Insert(BSCategory info)
        {
            string sqlstr = $"insert into BsCategory(BLID,BSName) values({info.BLID}, '{info.BSName}')";
            return SqlHelp.CUD(sqlstr);
        }
        public static int Update(BSCategory info)
        {
            string sqlstr = $"update BsCategory set BSName='{info.BSName}',BLID={info.BLID} where BSID={info.BSID}";
            return SqlHelp.CUD(sqlstr);
        }

    }
}
