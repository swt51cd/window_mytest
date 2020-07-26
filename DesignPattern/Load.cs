using System;

namespace DesignPattern
{
    class Load
    {
        static void Main(string[] args)
        {
            //Person myPerson = new Person("张三");

            #region 第一版
            //myPerson.show();
            //TSh mySh = new TSh();
            //mySh.show();
            //Shoes myShoes = new Shoes();
            //myShoes.show();
            #endregion

            #region 二版
            //TSh mySh = new TSh();
            //Tie myTie = new Tie();
            //Shoes myShoes = new Shoes();
            //Yd myYD = new Yd();

            //myShoes.Decorate(myPerson);
            //myYD.Decorate(myShoes);
            //myTie.Decorate(myYD);
            //mySh.Decorate(myTie);
            //mySh.show();
            #endregion

            #region 工厂
            /*
            IFactory factory = new XLFenFactory();
            LerFen student = factory.CreatLerFen();
            //Console.WriteLine("nameof="+nameof(student));
            student.Sd();
            student.Xi();
            */
            #endregion

            #region Dictionary
            int? myint=null;
            DictionayOperate.myDictionary(myint);
            #endregion

            Console.ReadKey();

        }
    }
}
