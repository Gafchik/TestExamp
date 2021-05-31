using DapperLib;
using System.Windows;

namespace Examp.View.Admin.Question
{
    /// <summary>
    /// Логика взаимодействия для EditQuestion.xaml
    /// </summary>
    public partial class EditQuestion : Window
    {
        private DapperLib.Question question;
        public EditQuestion(DapperLib.Question value)
        { 
            InitializeComponent();
            question = value;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            Question_Repository.Update(question, Name.Text);
            MessageBox.Show("Обновлено");
            this.Close();
        }
    }
}
