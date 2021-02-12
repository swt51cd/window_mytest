using System;
using System.Collections.Generic;
using System.Text;

namespace 迭代器
{
    public interface IIterator
    {
        bool IsNext();

        object Next();

    }
}
