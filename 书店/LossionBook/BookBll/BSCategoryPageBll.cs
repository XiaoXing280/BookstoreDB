using BookModel;
using BookDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class BSCategoryPageBll
    {
        public static List<BSCategory> SeletAll(int BLID) 
        {
            return BSCategoryPageDal.SeletAll(BLID);
        }
        public static List<BSCategory> SeletAll()
        {
            return BSCategoryPageDal.SeletAll();
        }
        public static BSCategory SeletByID(string BSID) 
        {
            return BSCategoryPageDal.SeletByID(BSID);
        }
        public static bool Deleter(int BSID)
        {
            int a = BSCategoryPageDal.Deleter(BSID);
            return a>0;
        }
        public static bool Insert(BSCategory info)
        {
            int a = BSCategoryPageDal.Insert(info);
            return a>0;
        }
        public static bool Update(BSCategory info) 
        {
            int a = BSCategoryPageDal.Update(info);
            return a>0;
        }

    }
}
