using System;

namespace 迭代器
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var  list=new 迭代器();
                //IIterator item = list.GetIterator();
                for (IIterator item = list.GetIterator(); item.IsNext();)
                {
                    string name =  (string)item.Next();
                    Console.WriteLine($"Hello World!-----{name}");
                }

                Console.ReadLine();
            }
            
           
        }
    }
}
