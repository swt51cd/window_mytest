using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox4.Text = @"D:\本地练习库\2017\window_mytest\CrawlerForm\bin\Debug";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbDialog =new FolderBrowserDialog();
            fbDialog.Description = @"保存的文件夹";
            fbDialog.ShowNewFolderButton = true;
            fbDialog.SelectedPath = Environment.CurrentDirectory;
            //fbDialog.ShowDialog();
            if (fbDialog.ShowDialog()==System.Windows.Forms.DialogResult.OK)
            {
                textBox4.Text = fbDialog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(@"搜索为空");
                return;
            }

            if (!Directory.Exists(textBox4.Text))
            {
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Enabled = false;
                width.Enabled = true;
                height.Enabled = true;
            }
            else
            {
                checkBox1.Enabled = true;
                width.Enabled = false;
                height.Enabled = false;
            }
        }
    }
}
