using BookDal;
using BooKModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BookBll
{
    public class AddressManagerBll
    {
        public static int Insert(AddressManager info)
        {
            //返回添加产生的ID
            return AddressManagerDal.Insert(info);
        }
        public static bool Update(AddressManager info)
        {
            int rows = AddressManagerDal.Update(info);
            return rows > 0;
        }
        public static bool Delete(int id)
        {
            int rows = AddressManagerDal.Delete(id);
            return rows > 0;
        }
        public static List<AddressManager> SelectAll() 
        {
            return AddressManagerDal.SelectAll();
        }
        public static AddressManager SelectForID(int id)
        {
            return AddressManagerDal.SelectForID(id);
        }

        public static List<AddressManager> SelectForUser(int userID)
        {
            return AddressManagerDal.SelectForUser(userID);
        }

        public static void UpdateDefault(int addID, int userID)
        {
            //using中的代码都包含在一个事务中
            using (TransactionScope ts = new TransactionScope())
            {
                //数据操作1
                AddressManagerDal.DeleteDefault(userID);
                //数据操作2
                AddressManagerDal.SetDefault(userID, addID);
                //提交事务，
                ts.Complete();//最后必须执行此代码，否则操作无效
                //不需要编写回滚代码，发生异常时自动回滚
            }
        }
        public static AddressManager SelectForDefault(int userID)
        {
            return AddressManagerDal.SelectForDefault(userID);
        }
    }
}
