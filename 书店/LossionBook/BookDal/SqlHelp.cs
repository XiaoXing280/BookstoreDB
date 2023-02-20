using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BookModel;

namespace BookDal
{
    public static class SqlHelp
    {
        //读取UI层中配置文件的数据库连接字符串
        static string conString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlJoin"].ConnectionString;

        /// <summary>
        /// 进行增删改的操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>受影响的行数</returns>
        public static int CUD(string sql)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand(sql, con);
                con.Open();
                return com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 进行增删改的操作
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="list">参数集合，防止SQL注入错误</param>
        /// <returns>受影响的行数</returns>
        public static int CUD(string sql, List<SqlParameter> list)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddRange(list.ToArray());
                con.Open();
                return com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 查询并返回第一行第一列的值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>第一行第一列的值</returns>
        public static object SelectSingle(string sql)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand(sql, con);
                con.Open();
                return com.ExecuteScalar();
            }
        }

        /// <summary>
        /// 查询并返回第一行第一列的值
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="list">参数集合，防止SQL注入错误</param>
        /// <returns>第一行第一列的值</returns>
        public static object SelectSingle(string sql, List<SqlParameter> list)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand(sql, con);
                com.Parameters.AddRange(list.ToArray());
                con.Open();
                return com.ExecuteScalar();
            }

        }
        /// <summary>
        /// 查询多条记录，并将数据封装到DataTable中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>查询的多条记录</returns>
        public static DataTable SelectDataSet(string sql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        /// <summary>
        /// 查询多条记录，并将数据封装到DataTable中
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="list">参数集合，防止SQL注入错误</param>
        /// <returns>查询的多条记录</returns>
        public static DataTable SelectDataSet(string sql, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.Parameters.AddRange(list.ToArray());
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        /// <summary>
        /// 执行查询，并返回SqlDataReader对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns>使用SqlDataReader读取查询的结果</returns>
        public static SqlDataReader SelectReader(string sql)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand com = new SqlCommand(sql, con);
            con.Open();
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>
        /// 执行查询，并返回SqlDataReader对象
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="list">参数集合，防止SQL注入错误</param>
        /// <returns>使用SqlDataReader读取查询的结果</returns>
        public static SqlDataReader SelectReader(string sql, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddRange(list.ToArray());
            con.Open();
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="list">参数集合</param>
        public static void ExecuteProc(string name, List<SqlParameter> list)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand com = new SqlCommand(name, con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddRange(list.ToArray());
                con.Open();
                com.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行存储过程，并返回查询结果
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="list">参数集合</param>
        /// <returns>使用SqlDataReader读取查询的结果</returns>
        public static SqlDataReader ExecuteProcReader(string name, List<SqlParameter> list)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand com = new SqlCommand(name, con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddRange(list.ToArray());
            con.Open();
            return com.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="info"></param>
        /// <param name="outPara"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteProcPage(proc_page info, SqlParameter outPara)
        {
            SqlConnection con = new SqlConnection(conString);
            SqlCommand com = new SqlCommand("proc_page", con);
            //设置分页存储过程的参数
            com.Parameters.AddWithValue("@PageIndex", info.PageIndex);
            com.Parameters.AddWithValue("@PageSize", info.PageSize);
            com.Parameters.AddWithValue("@TableName", info.TableName);
            com.Parameters.AddWithValue("@KeyName", info.KeyName);
            com.Parameters.AddWithValue("@Filter", info.Filter);
            com.Parameters.AddWithValue("@Where", info.Where);
            com.Parameters.AddWithValue("@Order", info.Order);
            //输出参数在此不能new，需要传递给调用者
            outPara.SqlDbType = SqlDbType.Int;
            outPara.ParameterName = "@dataCount";
            outPara.Direction = ParameterDirection.Output;
            com.Parameters.Add(outPara);
            com.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader read = com.ExecuteReader(CommandBehavior.CloseConnection);
            return read;

        }
    }
}
