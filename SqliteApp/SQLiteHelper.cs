using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using SqliteApp.Properties;

namespace SqliteApp
{
    public class SQLiteHelper
    {
        public SQLiteConnection Connection
        {
            get
            {
                if (_cn == null)
                {
                    Settings settings = new Settings();
                    string connection = settings.Context.ToString();
                    _cn = new SQLiteConnection(connection);
                }
                return _cn;
            }
        }

        private SQLiteConnection _cn = null;

        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection.Open();
                GetAdapter(query).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return dt;
        }

        public bool Update(string tableName, DataTable dt)
        {
            try
            {
                Connection.Open();
                string tableStructureQuery = string.Format("SELECT * FROM {0} WHERE 1 = 0", tableName);
                SQLiteDataAdapter da = GetAdapter(tableStructureQuery);
                da.Update(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return true;
        }

        public SQLiteDataAdapter GetAdapter(string query)
        {
            SQLiteCommand selectCommand = new SQLiteCommand(query, Connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand);
            SQLiteCommandBuilder sb = new SQLiteCommandBuilder(adapter);
            return adapter;
        }

        public bool ExecuteScript(string query)
        {
            try
            {
                SQLiteCommand selectCommand = new SQLiteCommand(query, Connection);
                Connection.Open();
                selectCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return true;
        }
    }

    public static class DataViewHelper
    {
        public static DataView Clone(this DataView source, string filter)
        {
            if (source == null)
            {
                throw new ApplicationException("Source cannot be null");
            }

            DataView newView = new DataView(source.Table);

            string viewfilter = source.RowFilter;

            List<string> filters = new List<string>();
            if (!string.IsNullOrEmpty(viewfilter))
                filters.Add(string.Format("({0})", viewfilter));
            if (!string.IsNullOrEmpty(filter))
                filters.Add(string.Format("({0})", filter));

            newView.RowFilter = string.Join(" AND ", filters.ToArray());

            return newView;
        }

        public static DataView Clone(this DataView source)
        {
            return source.Clone(string.Empty);
        }
    }
}
