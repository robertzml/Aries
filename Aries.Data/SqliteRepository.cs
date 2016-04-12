using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;   

namespace Aries.Data
{
    /// <summary>
    /// SQLite连接
    /// </summary>
    public class SQLiteRepository : IDisposable
    {
        #region Field
        /// <summary>
        /// 数据源
        /// </summary>
        private string datasource = @"aries.db";

        /// <summary>
        /// 是否已连接
        /// </summary>
        private bool isOpen;

        /// <summary>
        /// 是否清理
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// SQLite连接
        /// </summary>
        private SQLiteConnection connection;

        /// <summary>
        /// 参数
        /// </summary>
        private Dictionary<string, string> parameters;

        /// <summary>
        /// 错误消息
        /// </summary>
        private string errorMessage;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 连接默认数据库
        /// </summary>
        public SQLiteRepository()
        {
            init("");
        }

        /// <summary>
        /// 连接指定的数据库
        /// </summary>
        /// <param name="basePath">根目录</param>
        public SQLiteRepository(string basePath)
        {
            init(basePath + "\\" + datasource);
        }

        /// <summary>
        /// 清理托管资源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 清理所有使用资源
        /// </summary>
        /// <param name="disposing">如果为true则清理托管资源</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // dispose all managed resources.
                if (disposing)
                {
                    this.isOpen = false;
                    connection.Dispose();
                }

                // dispose all unmanaged resources
                this.Close();

                disposed = true;
            }
        }

        /// <summary>
        /// 析构函数
        /// </summary>
        ~SQLiteRepository()
        {
            Dispose(false);
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="datasource">数据源</param>
        private void init(string datasource)
        {
            if (datasource != "")
                this.datasource = datasource;
            this.connection = new SQLiteConnection("data source = " + this.datasource);
            this.parameters = new Dictionary<string, string>();
            this.isOpen = false;
        }

        private bool checkDbExist()
        {
            if (System.IO.File.Exists(datasource))
                return true;
            else
                return false;
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 打开连接
        /// </summary>
        public void Open()
        {
            if (!isOpen)
                connection.Open();

            this.isOpen = true;
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Close()
        {
            if (isOpen)
                connection.Close();

            this.isOpen = false;
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">参数名</param>
        /// <param name="value">参数值</param>
        public void AddParameter(string key, string value)
        {
            parameters.Add(key, value);
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql">SQL语句</param>
        public void ExecuteNonQuery(string sql)
        {
            this.Open();
            try
            {
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = sql;
                        foreach (KeyValuePair<string, string> kvp in this.parameters)
                        {
                            command.Parameters.Add(new SQLiteParameter(kvp.Key, kvp.Value));
                        }

                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }
            catch (SQLiteException e)
            {
                this.errorMessage = e.Message;
            }
            finally
            {
                this.Close();
                this.parameters.Clear();
            }
        }

        /// <summary>
        /// 执行SQL语句并返回所有结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            this.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    command.CommandText = sql;
                    foreach (KeyValuePair<string, string> kvp in this.parameters)
                    {
                        command.Parameters.Add(new SQLiteParameter(kvp.Key, kvp.Value));
                    }

                    adapter.Fill(dt);
                }
            }
            catch (SQLiteException e)
            {
                this.errorMessage = e.Message;
                return null;
            }
            finally
            {
                this.Close();
                this.parameters.Clear();
            }
            return dt;
        }

        /// <summary>
        /// 执行SQL语句并返回第一行
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataRow</returns>
        public DataRow ExecuteRow(string sql)
        {
            DataRow row;
            this.Open();
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    command.CommandText = sql;
                    foreach (KeyValuePair<string, string> kvp in this.parameters)
                    {
                        command.Parameters.Add(new SQLiteParameter(kvp.Key, kvp.Value));
                    }

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    if (dt.Rows.Count == 0)
                        row = null;
                    else
                        row = dt.Rows[0];
                }
            }
            catch (SQLiteException e)
            {
                this.errorMessage = e.Message;
                return null;
            }
            finally
            {
                this.Close();
                this.parameters.Clear();
            }
            return row;
        }

        /// <summary>
        /// 执行SQL语句并返回结果第一行的第一列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回值</returns>
        public Object ExecuteScalar(string sql)
        {
            Object obj;
            this.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = sql;
                foreach (KeyValuePair<string, string> kvp in this.parameters)
                {
                    command.Parameters.Add(new SQLiteParameter(kvp.Key, kvp.Value));
                }
                obj = command.ExecuteScalar();
            }
            this.Close();
            this.parameters.Clear();

            return obj;
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return this.errorMessage;
            }
        }
        #endregion //Property
    }
}
