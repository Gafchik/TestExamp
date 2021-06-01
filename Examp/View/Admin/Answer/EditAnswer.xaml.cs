using DapperLib;
using System.Windows;

namespace Examp.View.Admin.Answer
{
    /// <summary>
    /// Логика взаимодействия для EditAnswer.xaml
    /// </summary>
    public partial class EditAnswer : Window
    {
        private DapperLib.Answer answer;
        public EditAnswer(DapperLib.Answer value)
        {
            answer = value;
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "" || Name.Text == null)
                return;
            if (check.IsChecked.Value)
            {
                Answer_Repository.Update(answer, Name.Text, true);
                MessageBox.Show("Добавлнео, назначено");
                this.Close();
            }
            else
            {
                Answer_Repository.Update(answer, Name.Text);
                MessageBox.Show("Добавлнео");
                this.Close();
            }

        }
    }
}


