using BookModel;
using BookDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class BLCategoryPageBll
    {
        public static List<BLCategory> SeletAll()
        {
            return BLCategoryPageDal.SeletAll();
        }
        public static List<BLCategory> SeletAll(int BLID) 
        {
            return BLCategoryPageDal.SeletAll(BLID);
        }
        public static BLCategory SeletByID(string BLID) 
        {
            return BLCategoryPageDal.SeletByID(BLID);
        }
        public static bool Deleter(int BLID) 
        {
            int a = BLCategoryPageDal.Deleter(BLID);
            return a>0;
        }
        public static bool Insert(BLCategory info) 
        {
            int a = BLCategoryPageDal.Insert(info);
            return a>0;
        }
        public static bool Update(BLCategory info) 
        {
            int a = BLCategoryPageDal.Update(info);
            return a > 0;
        }
    }
}
