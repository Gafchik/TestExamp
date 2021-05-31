using Examp.ModelView.Admin.Answer;
using System.Windows;

namespace Examp.View.Admin.Answer
{
    /// <summary>
    /// Логика взаимодействия для AnswerWindow.xaml
    /// </summary>
    public partial class AnswerWindow : Window
    {
        public static DapperLib.Question question;
        public AnswerWindow(DapperLib.Question value)
        {
            InitializeComponent();
            question = value;
            DataContext = new AnswerWindow_ViewModel(question);          
        }

        
    }
}
