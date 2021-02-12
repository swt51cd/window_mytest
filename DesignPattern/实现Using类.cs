using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace DesignPattern
{
    class 实现Using类
    {
        public static void Using_Main()
        {
            var computer = new Computer();
            //try
            //{
            //    computer.Play();
            //}
            //finally 
            //{
            //    computer.Destory();
            //}

            using (new 封装类(computer)) 
            {
                computer.Play();
            }
            Console.ReadKey();
        }
    }

    public class Computer
    {
        public void Play()
        {
            Console.WriteLine("播放电影");
        }

        public void Destory()
        {
            Console.WriteLine("销毁Computer---->"+this);
        }
    }

    public class 封装类:IDisposable
    {
        private Computer computer;
        public 封装类(Computer computer)
        {
            this.computer = computer;
        }

        public void Dispose()
        {
            computer.Destory();
        }
    }

}
