using DapperLib;
using System.Windows;

namespace Examp.View.Admin.Test
{
    /// <summary>
    /// Логика взаимодействия для NewTest.xaml
    /// </summary>
    public partial class NewTest : Window
    {
        private DapperLib.Category category;
        public NewTest(DapperLib.Category value)
        {
            category = value;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Test_Repository.Create(new DapperLib.Test { Test_Name = Name.Text }, category.Category_ID);
            MessageBox.Show("Добавлнео");
            this.Close();
        }
    }
}
