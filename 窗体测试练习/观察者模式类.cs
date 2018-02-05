using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体测试练习
{
    #region 早期版本
    class 观察者模式类
    {
        public ListBox Mylistbox { get; set; } = null;
        private IList<Observer投资者> myobserver = new List<Observer投资者>();
        public string 前台状态 { get; set; } = null;
        public void 添加(Observer投资者 vObserver)
        {
            myobserver.Add(vObserver);
            Mylistbox.Items.Add($"添加--通知对象【{nameof(vObserver)}】"+vObserver.MyName);
        }
        //通知
        public void Notify()
        {
            foreach (Observer投资者 o in myobserver)
            {
                o.Update动作();
            }
        }
    }
    class Observer投资者
    {
        protected ListBox _listBox;
        public ListBox Mylistbox { get=>_listBox; set { _listBox = value; } }
        private string _name;
        public string MyName { get=>_name; set { _name = value; } }
        public Observer投资者(string vname)
        {
            _name = vname;
        }
        public void Update动作()
        {
            _listBox.Items.Add($"[Update动作]---{_name }收到信息****后=>做些事情*Update动作*");
        }
    }

    #endregion

    #region 第一版本
    class 秘书类
    {
        private IList<观察者base> 观察者们 =new List<观察者base>();
        private string _action;
        public string  My状态 { get=>_action; set {_action=value; } }

        protected ListBox _listBox;
        public ListBox Mylistbox { get => _listBox; set { _listBox = value; } }

        public void Add(观察者base v观察者类)
        {
            观察者们.Add(v观察者类);
            _listBox.Items.Add($"添加--通知对象【{nameof(v观察者类)}】***" + v观察者类.MyName);
        }
        public void Notify()
        {
            foreach (观察者base o in 观察者们)
            {
                o.Update动作();
            }
        }
     }

    abstract class 观察者base
    {
        protected string _name;
        public string MyName { get => _name; set { _name = value; } }
        protected 秘书类 私人秘书;
        public abstract void Update动作();
        protected ListBox _listbox;
        public ListBox Mylistbox { get => _listbox; set { _listbox = value; } }
        public 观察者base(string name, 秘书类 v秘书)
        {
            this.私人秘书 = v秘书;
            this._name = name;
        }

    }
    class 同事_投资 : 观察者base
    {
        public override void Update动作()
        {
            this.Mylistbox.Items.Add($"通知者说【{this.私人秘书.My状态}】--- {this.MyName}关闭股票--开始工作");
        }
        public 同事_投资(string name,秘书类 v秘书):base(name,v秘书)
        {

        }
    }

    class 同事_NBA : 观察者base
    {
        public override void Update动作()
        {
            this.Mylistbox.Items.Add($"通知者说[{this.私人秘书.My状态}]---{nameof(this.MyName)}关闭NBA--开始工作");
        }
        public 同事_NBA(string name, 秘书类 v秘书) : base(name, v秘书)
        {

        }
    }
    #endregion

}
