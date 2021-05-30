using DapperLib;
using System.Windows;

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
