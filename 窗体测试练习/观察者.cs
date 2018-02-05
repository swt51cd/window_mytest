using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 窗体测试练习
{
    public partial class 观察者 : Form
    {
        public 观察者()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 最开始版本
            /*
            观察者模式类 前台小微 = new 观察者模式类();
            前台小微.Mylistbox = listBox2;
            Observer投资者 同事张 = new Observer投资者("开发部张三");
            同事张.Mylistbox = listBox1;
            同事张.MyName = "讨厌的张三";
            前台小微.添加(同事张);
            前台小微.前台状态 = "老板来---通知大家";
            前台小微.Notify();
             */
            #endregion

            #region 第一版**
            秘书类 前台小微 = new 秘书类();
            前台小微.Mylistbox = listBox2;
           
            观察者base 同事张三 = new 同事_投资("张三", 前台小微);
            同事张三.Mylistbox = listBox1;
            观察者base 同事李四 = new 同事_NBA("李四", 前台小微);
            同事李四.Mylistbox = listBox1;

            前台小微.Add(同事张三);
            前台小微.Add(同事李四);
            前台小微.My状态 = "老板来";
            前台小微.Notify();
            #endregion
        }


        private void 观察者_Load(object sender, EventArgs e)
        {

        }
    }
}
