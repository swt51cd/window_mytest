using System;
using System.Collections.Generic;
using System.Text;

namespace 迭代器
{
    public class 迭代器 
    {
        private static string[] names = { "实验班", "一年级", "二年级", "三年级", "四年级" };

        public string[] GetNames()
        {
            return names;
        }

        public IIterator GetIterator()
        {
            return new ListIterator();
            
        }

        //私有类
        private class ListIterator : IIterator
        {
            private int index;

            public bool IsNext()
            {
                if (index < names.Length)
                {
                    return true;
                }

                return false;
            }

            public object Next()
            {
                if (IsNext())
                {
                    return names[index++];
                }

                return null;
            }

        }
    }
}
