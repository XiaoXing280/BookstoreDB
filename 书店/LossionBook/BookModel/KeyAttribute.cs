using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksModel
{
    /// <summary>
    /// �Զ���������(���ڴ洢ʵ�������������)
    /// </summary>
    public class KeyAttribute:Attribute
    {
        public KeyAttribute(string keyName)
        {
            this.KeyName = keyName;
        }
        public string KeyName { get; set; }//�洢��������
    }
}
