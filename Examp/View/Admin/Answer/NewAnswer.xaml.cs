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

namespace Examp.View.Admin.Answer
{
    /// <summary>
    /// Логика взаимодействия для NewAnswer.xaml
    /// </summary>
    public partial class NewAnswer : Window
    {
        private DapperLib.Question question;
        public NewAnswer(DapperLib.Question value)
        {
            question = value;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            if(check.IsChecked.Value)
            {
                Answer_Repository.Create_True(new DapperLib.Answer { Answer_Text = Name.Text }, question.Question_ID,true);
                MessageBox.Show("Добавлнео, назначено");
                this.Close();
            }
            else
            {
                Answer_Repository.Create(new DapperLib.Answer { Answer_Text = Name.Text }, question.Question_ID);
                MessageBox.Show("Добавлнео");
                this.Close();
            }
           
        }
    }
}


