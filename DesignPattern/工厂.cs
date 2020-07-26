using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class LerFen
    {
        public void Sd()
        {
            Console.WriteLine("扫地");
        }
        public void Xi()
        {
            Console.WriteLine("洗衣");
        }
    }

    class XunLerFen:LerFen {}
    class SeQZy:LerFen {}
    interface IFactory
    {
        LerFen CreatLerFen();
    }
    class XLFenFactory:IFactory
    {
        public LerFen CreatLerFen()
        {
            Console.WriteLine("学雷锋");
            return new XunLerFen();
        }
    }
    class SQZyFactory:IFactory
    {
        public LerFen CreatLerFen()
        {
            Console.WriteLine("社区学雷锋");
            return new SeQZy();
        }
    }
 

}
