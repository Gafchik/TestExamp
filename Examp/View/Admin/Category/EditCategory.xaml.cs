using DapperLib;
using System.Windows;

namespace Examp.View.Admin.Category
{
    /// <summary>
    /// Логика взаимодействия для EditCategory.xaml
    /// </summary>
    public partial class EditCategory : Window
    {
        private DapperLib.Category category;
        public EditCategory(DapperLib.Category value)
        {
            InitializeComponent();
            category = value;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Category_Repository.Update(category, Name.Text);
            MessageBox.Show("Обновлено");
            this.Close();
        }
    }
}
