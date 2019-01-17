using System;
using System.Windows.Forms;

namespace 窗体测试练习
{
    public partial class Dog回调事件 : Form
    {
        private Button button1;
        private Button button2;
        private ListBox listBox1;

        public Dog回调事件()
        {
            InitializeComponent();
        }
       private void button2_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog();
            dog.MyListBox = listBox1;
            Host host = new Host(dog);

            //当前时间，从2008年12月31日23:59:50开始计时
            DateTime now = new DateTime(2015, 12, 31, 23, 59, 50);
            DateTime midnight = new DateTime(2016, 1, 1, 0, 0, 0);

            //等待午夜的到来
            listBox1.Items.Add("时间一秒一秒地流逝... ");
            while (now < midnight)
            {
                listBox1.Items.Add("当前时间: " + now);
                System.Threading.Thread.Sleep(1000);    //程序暂停一秒
                now = now.AddSeconds(1);                //时间增加一秒
            }

            //午夜零点小偷到达,看门狗引发Alarm事件
            listBox1.Items.Add("\n月黑风高的午夜: " + now);
            listBox1.Items.Add("小偷悄悄地摸进了主人的屋内... ");
            dog.OnAlarm();
        }

        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(189, 55);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(685, 352);
            this.listBox1.TabIndex = 2;
            // 
            // Dog回调事件
            // 
            this.ClientSize = new System.Drawing.Size(880, 410);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Dog回调事件";
            this.ResumeLayout(false);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
    /*
    * 在进行回调函数/事件触发的编写时，要遵循：  事件发送者监听，当监听到某一临界条件成立后，将事件告知事件接收者，
    * 由事件接收者完成后续动作。此处的事件接收者就是本文要讲的回调函数。
    * 关键点就是触发回调函数的执行，而触发回调函数的执行，关键点是订阅事件，因此，理解事件的订阅及触发后，回调函数就也没什么了！
    * 
    * 
    * 
    * 事件处理委托习惯上以EventHandler结尾，比如AlarmEventHandler。事件Alarm实际上是事件处理委托AlarmEventHandler的一个实例。
    * 引发事件的代码常常被编写成一个函数，.NET约定这种函数的名称为“OnEventName”，比如OnAlarm()的函数。在Host类中，
    * 我们定义了事件处理程序HostHandleAlarm()，并把它注册到dog.Alarm事件中。
    */


    class Dog //事件发送者
    {
        //1.声明关于事件的委托；
        public delegate void AlarmEventHandler(object sender, EventArgs e);

        //2.声明事件；   
        public event AlarmEventHandler Alarm;
        public ListBox MyListBox { get; set; } = null;
        //3.编写引发事件的函数；
        public void OnAlarm()
        {
            
            if (this.Alarm != null)
            {
                MyListBox.Items.Add("\n狗报警: 有小偷进来了,汪汪~~~~~~~");
                this.Alarm(this, new EventArgs());   //发出警报
            }
        }
    }

    class Host//事件接收者
    {
        private readonly ListBox _listBox;

        //４.编写事件处理程序
        void HostHandleAlarm(object sender, EventArgs e)
        {
            _listBox.Items.Add("主人: 抓住了小偷！");
        }

        //５.注册事件处理程序
        public Host(Dog dog)
        {
            _listBox = dog.MyListBox; 
            dog.Alarm += new Dog.AlarmEventHandler(HostHandleAlarm);
        }
    }
   

}
