using System;
using System.Windows.Forms;

namespace 窗体测试练习
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new 观察者());
            Application.Run(new Dog回调事件());
        }
    }
}
