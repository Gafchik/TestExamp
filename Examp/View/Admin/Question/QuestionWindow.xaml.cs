using Examp.ModelView.Admin.Question;
using System.Windows;

namespace Examp.View.Admin.Question
{
    /// <summary>
    /// Логика взаимодействия для QuestionWindow.xaml
    /// </summary>
    public partial class QuestionWindow : Window
    {
        public static DapperLib.Test test;
        public QuestionWindow(DapperLib.Test value)
        {
            InitializeComponent();
            test = value;
            DataContext = new QuestionWindow_ModelView(test);
        }
    }
}
