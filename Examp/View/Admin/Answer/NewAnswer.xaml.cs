using DapperLib;
using System.Windows;

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


