using Examp.ModelView.Admin.Answer;
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
