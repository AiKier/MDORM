using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;

namespace MDORM.DapperExt.Mapper
{
    /// <summary>
    /// �Զ���һ��ʵ��ӳ�䵽һ����ʹ�÷��������Լ������ϼ�
    /// Automatically maps an entity to a table using a combination of reflection and naming conventions for keys.
    /// </summary>
    public class AutoClassMapper<T> : ClassMapper<T> where T : class
    {
        public AutoClassMapper()
        {
            Type type = typeof(T);
            Table(type.Name);
            AutoMap();
        }
    }
}