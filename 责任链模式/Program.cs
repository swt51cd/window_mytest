using System;

namespace 责任链模式
{
    class Program
    {
        static void Main(string[] args)
        {
            var ment = new 主管()
            {
                Name = "刘主管",
                Days = 7
            };

            var manager = new 经理()
            {
                Name = "孙经理",
                Days = 15
            };
            var ceo = new 总裁()
            {
                Name = "张总裁",
                Days = 30
            };

            var context = new LeaveContext()
            {
                Day = 12,
                Description = "shuoming,123，ABC"
            };

            #region 第一种 顺序排列：依次转交
            //ment.SetHandler(manager) ;
            //manager.SetHandler(ceo);
            //ment.HandlerLeaveRequest(context);
            #endregion

            #region 第二种 无序排列 ：只要结果
            //var chain = new Chain(); //链
            //chain.Add(ment).Add(manager).Add(ceo);
            //chain.HandlerLeaveRequest(context);

            #endregion

            #region 第三种 无序排列 ：过滤
            var chain = new Chain(); //链
            chain.Add(ment).Add(manager).Add(ceo);
            chain.Filter(context);
            #endregion



            Console.ReadLine();

        }
    }
}
