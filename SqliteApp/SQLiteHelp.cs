using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqliteApp.Properties;

namespace SqliteApp
{
    public class SQLiteHelp
    {
        public SQLiteHelp()
        {
            SQLiteConnection conn = null;
            string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";
            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            string sql = "CREATE TABLE IF NOT EXISTS student(id integer, name varchar(20), sex varchar(2));";//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  

            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = "INSERT INTO student VALUES(1, '小红', '男')";//插入几条数据  
            cmdInsert.ExecuteNonQuery();
            cmdInsert.CommandText = "INSERT INTO student VALUES(2, '小李', '女')";
            cmdInsert.ExecuteNonQuery();
            cmdInsert.CommandText = "INSERT INTO student VALUES(3, '小明', '男')";
            cmdInsert.ExecuteNonQuery();
            conn.Close();
        }


    }

   
}
