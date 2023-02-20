using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksModel
{
    /// <summary>
    /// 自定义特性类(用于存储实体类的主键名称)
    /// </summary>
    public class KeyAttribute:Attribute
    {
        public KeyAttribute(string keyName)
        {
            this.KeyName = keyName;
        }
        public string KeyName { get; set; }//存储主键名称
    }
}
