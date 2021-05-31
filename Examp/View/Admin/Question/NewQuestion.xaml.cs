using DapperLib;
using System.Windows;

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
