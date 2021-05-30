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
