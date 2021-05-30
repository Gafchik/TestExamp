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

namespace Examp.View.Admin.Category
{
    /// <summary>
    /// Логика взаимодействия для NewCategory.xaml
    /// </summary>
    public partial class NewCategory : Window
    {
        public NewCategory()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Category_Repository.Create(new DapperLib.Category { Category_Name = Name.Text });
            MessageBox.Show("Добавлнео");
            this.Close();
        }
    }
}
