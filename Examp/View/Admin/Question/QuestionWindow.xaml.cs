using Examp.ModelView.Admin.Question;
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
