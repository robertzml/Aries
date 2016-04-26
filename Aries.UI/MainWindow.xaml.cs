using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Aries.Business;
using Aries.Model;
using System.IO;
using Aries.ImageProcess;

namespace Aries.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddChildWindow window = new AddChildWindow();
            window.ShowDialog();
        }

        private void buttonSelectImage_Click(object sender, RoutedEventArgs e)
        {
            ImageBusiness imageBusiness = new ImageBusiness();
            

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG|*.jpg|BMP|*.bmp|PNG|*.png";
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                for(int i = 0; i < dialog.FileNames.Length; i++)
                {
                    ChildImage image = new ChildImage();
                    image.ChildId = 1;
                    image.Date = DateTime.Now;
                 
                    image.Title = dialog.SafeFileNames[i];
                    
                    FileStream picStream = File.OpenRead(dialog.FileNames[i]);
                    byte[] bArray = new byte[picStream.Length];
                    picStream.Read(bArray, 0, bArray.Length);
                    picStream.Close();
                    image.Blob = bArray;

                    ImageExif imageExif = new ImageExif(dialog.FileNames[i]);
                    image.Date = imageExif.DateTime;

                    imageBusiness.Add(image);
                }
            }
        }
    }
}
