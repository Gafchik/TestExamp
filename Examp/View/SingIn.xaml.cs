using DapperLib;
using System.Linq;
using System.Windows;
using Examp.View.Admin;
using Examp.View.User.Category;

namespace Examp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(log.Text == null || log.Text ==""|| pass.Password == null || pass.Password =="")
            {
                MessageBox.Show("Вы ничего не ввели");
                return;
            }
            else if(User_Repository.Select().ToList().Exists(i=> i.User_Login == log.Text || i.User_Pass == pass.Password))
            {
                MessageBox.Show("Вы Вошли как пользователь");
                var windiw = new UserCategoryWindow();
                windiw.Show();
                this.Close();
            }
            else if (Admin_Repository.Select().ToList().Exists(i => i.Admin_Login == log.Text || i.Admin_Pass == pass.Password))
            {
                MessageBox.Show("Вы Вошли как админ");
                var windiw = new AdminWindow();
                windiw.Show();
                this.Close();
            }
            else
                MessageBox.Show("Не верный логин и пароль");
        }
    }
}
