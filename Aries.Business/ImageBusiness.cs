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
    /// 图片业务类
    /// </summary>
    public class ImageBusiness
    {
        #region Field
        /// <summary>
        /// SQLite连接
        /// </summary>
        private SQLiteRepository sqlite;
        #endregion //Field

        #region Constructor
        public ImageBusiness()
        {
            this.sqlite = new SQLiteRepository();
        }
        #endregion //Constructor

        #region Method
        public ErrorCode Add(ChildImage image)
        {
            try
            {
                this.sqlite.AddChildImage(image);
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
