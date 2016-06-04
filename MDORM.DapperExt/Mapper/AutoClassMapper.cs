using System;

namespace MDORM.DapperExt.Mapper
{
    /// <summary>
    /// �Զ���һ��ʵ��ӳ�䵽һ����ʹ�÷��������Լ������ϼ�
    /// Automatically maps an entity to a table using a combination of reflection and naming conventions for keys.
    /// </summary>
    public class AutoClassMapper<T> : ClassMapper<T> where T : class
    {
        /// <summary>
        /// �Զ�������ӳ��
        /// </summary>
        public AutoClassMapper()
        {
            Type type = typeof(T);
            Table(type.Name);
            AutoMap();
        }
    }
}