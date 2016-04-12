using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aries.Data;
using Aries.Model;

namespace Aries.Business
{
    /// <summary>
    /// 小孩业务类
    /// </summary>
    public class ChildBusiness
    {
        #region Field
        /// <summary>
        /// SQLite连接
        /// </summary>
        private SQLiteRepository sqlite;
        #endregion //Field

        #region Constructor
        public ChildBusiness()
        {
            this.sqlite = new SQLiteRepository();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 添加小孩
        /// </summary>
        /// <param name="data">小孩对象</param>
        /// <returns></returns>
        public ErrorCode Add(Child data)
        {
            try
            {
                string sql = string.Format("INSERT Child(Name, Birth) VALUES('{0}', '{1}')", data.Name, data.Birth);
                this.sqlite.ExecuteNonQuery(sql);
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Method
    }
}
