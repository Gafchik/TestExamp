using DapperLib;
using System.Windows;

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
