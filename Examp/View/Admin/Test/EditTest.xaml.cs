using DapperLib;
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

namespace Examp.View.Admin.Test
{
    /// <summary>
    /// Логика взаимодействия для EditTest.xaml
    /// </summary>
    public partial class EditTest : Window
    {
        private DapperLib.Test category;
        public EditTest(DapperLib.Test value)
        {
            InitializeComponent();
            category = value;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Test_Repository.Update(category, Name.Text);
            MessageBox.Show("Обновлено");
            this.Close();
        }
    }
}
