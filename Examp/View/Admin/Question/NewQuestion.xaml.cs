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

namespace Examp.View.Admin.Question
{
    /// <summary>
    /// Логика взаимодействия для NewQuestion.xaml
    /// </summary>
    public partial class NewQuestion : Window
    {
        private DapperLib.Test test;
        public NewQuestion(DapperLib.Test value)
        {
            test = value;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Question_Repository.Create(new DapperLib.Question { Question_Text = Name.Text }, test.Test_ID);
            MessageBox.Show("Добавлнео");
            this.Close();
        }

    }
}
