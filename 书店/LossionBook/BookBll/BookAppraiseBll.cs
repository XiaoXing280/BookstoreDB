using BookDal;
using BookModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBll
{
    public class BookAppraiseBll
    {
        public static List<BookAppraise> GetModelListBySqlStr(int BookID) 
        {
            return BookAppraiseDal.GetModelListBySqlStr(BookID);
        }
    }
}
