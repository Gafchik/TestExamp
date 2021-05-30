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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Examp.View.Admin;

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
                var windiw = new AdminWindow();
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
