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
using System.Windows.Shapes;
using Aries.Business;
using Aries.Model;

namespace Aries.UI
{
    /// <summary>
    /// AddChildWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AddChildWindow : Window
    {
        public AddChildWindow()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            string name = this.textBoxName.Text;
            DateTime birth = this.calendarBirth.SelectedDate.Value;

            Child child = new Child
            {
                Name = name,
                Birth = birth
            };

            ChildBusiness childBusiness = new ChildBusiness();
            ErrorCode result = childBusiness.Add(child);
            if (result == ErrorCode.Success)
            {
                this.Close();
            }
        }
    }
}
