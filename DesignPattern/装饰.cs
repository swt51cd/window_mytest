using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern
{
    class Person
    {
        private string _name;
        public int MyCount { get; set; } = 1;
        public string Name { get => _name; set => _name = value; }
        
        public Person(string strName)
        {
            this._name = strName;
            Console.WriteLine("构造函数");
        }
        public Person() {}
       
        public virtual void show()
        {
            Console.WriteLine($"姓名={_name} 今天穿着打扮");

        }
    }
    abstract class FineryComponent
    {
        public abstract void Operation();
    }
    abstract class Decorator:FineryComponent
    {
        //public override
        protected FineryComponent myFineryComponent;
        public void SetComponent(FineryComponent vConponent)
        {
            this.myFineryComponent = vConponent;
        }
        public override void Operation()
        {
            if (myFineryComponent!=null)
            {
                myFineryComponent.Operation();
            }
        }
    }

    #region 抽象类 服饰Finery 接口
    abstract class Finery:Person
    {
        //public abstract void show();
        protected Person GetPerson;
        //打扮
        public void Decorate(Person vPerson)
        {
            this.GetPerson = vPerson;
        }
        public override void show()
        {
            if (GetPerson!=null)
            {
                GetPerson.show();
            }
            
        }
    }
    #endregion

    #region T恤 类
    class TSh : Finery
    {
        public override void show()
        {
            Console.WriteLine("T恤");
            base.show();
        }
    }
    #endregion

    #region 领带
    class Tie:Finery
    {
        public override void show()
        {
            Console.WriteLine("领带");
            base.show();
        }
        
    }
    #endregion

    #region 鞋 类
    class Shoes : Finery
    {
        public override void show()
        {
            Console.WriteLine("穿鞋");
            base.show();
        }
       
    }
    #endregion

    #region 腰带
    class Yd:Finery
    {
        public override void show()
        {
            Console.WriteLine("-->腰带<--");
            base.show();
        }

    }
    #endregion


}
