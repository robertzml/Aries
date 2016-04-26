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
using Aries.Business;
using Aries.Model;
using Aries.ImageProcess;
using DevExpress.XtraBars.Ribbon;

namespace Aries.FormClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Event
        /// <summary>
        /// 显示所有
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImageBusiness imageBusiness = new ImageBusiness();
            var data = imageBusiness.ReadAll();
                       
          
            this.mainGallery.Gallery.ShowItemText = true;

            GalleryItemGroup group1 = new GalleryItemGroup();
            group1.Caption = "Cars";
            this.mainGallery.Gallery.Groups.Add(group1);

            foreach(var item in data)
            {
                MemoryStream streamImage = new MemoryStream(item.Blob);
                Image image = Image.FromStream(streamImage);
                group1.Items.Add(new GalleryItem(image, item.Title, ""));
            }                        
        }

        private void barBtnAddFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImageBusiness imageBusiness = new ImageBusiness();
            
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG|*.jpg|BMP|*.bmp|PNG|*.png";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < dialog.FileNames.Length; i++)
                {
                    FileStream picStream = File.OpenRead(dialog.FileNames[i]);
                    byte[] bArray = new byte[picStream.Length];
                    picStream.Read(bArray, 0, bArray.Length);            

                    ImageExif imageExif = new ImageExif(dialog.FileNames[i]);                  

                    imageBusiness.Add(1, dialog.SafeFileNames[i], bArray, imageExif.DateTime);
                }
            }
        }
        #endregion //Event

       
    }
}
