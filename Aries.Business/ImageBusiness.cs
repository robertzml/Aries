using System;
using System.Collections.Generic;
using System.Data;
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

        public ErrorCode Add(int childId, string filename, byte[] blob, DateTime date)
        {
            ChildImage image = new ChildImage
            {
                Id = Guid.NewGuid(),
                ChildId = childId,
                FileName = filename,
                Date = date,
                Title = filename.Substring(0, filename.LastIndexOf('.')),
                Blob = blob,
                Description = ""
            };

            this.sqlite.AddChildImage(image);
            return ErrorCode.Success;
        }


        public List<ChildImage> ReadAll()
        {
            string sql = "SELECT * FROM ImageStore";
            DataTable dt = this.sqlite.ExecuteQuery(sql);

            List<ChildImage> images = new List<ChildImage>();
            foreach(DataRow row in dt.Rows)
            {
                ChildImage image = new ChildImage();
                image.Id = new Guid(row["Id"].ToString());
                image.ChildId = Convert.ToInt32(row["ChildId"]);
                image.FileName = row["FileName"].ToString();
                image.Date = Convert.ToDateTime(row["ImageDate"]);
                image.Title = row["ImageTitle"].ToString();
                image.Blob = row["ImageBlob"] as byte[];
                image.Description = row["Description"].ToString();

                images.Add(image);
            }

            return images;
        }

        public ChildImage Read(DateTime date)
        {


            return null;
        }
        #endregion //Method
    }
}
