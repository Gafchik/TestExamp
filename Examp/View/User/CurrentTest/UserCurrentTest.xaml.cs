using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DapperLib;

namespace Examp.View.User.CurrentTest
{
    /// <summary>
    /// Логика взаимодействия для UserCurrentTest.xaml
    /// </summary>
    public partial class UserCurrentTest : Window 
    {
       
        List<Question> _questions;
        DispatcherTimer _timer; // таймер
        TimeSpan _time; // время для таймера

        public DapperLib.Test test;
        public UserCurrentTest(DapperLib.Test value)
        {
            InitializeComponent();
            test = value;            // текущий тест       
            Test_L.Content = value.Test_Name; // лейбыл для отображения имени

            _time = TimeSpan.FromMinutes(10); // интервал таймера

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Timer_L.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) // что  происходит когда время вышло
                { 
                    _timer.Stop();
                    MessageBox.Show("Время вышло");
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start(); // старт таймера

            _questions = Question_Repository.Select().ToList().FindAll(i => i.Question_Test_ID == test.Test_ID);
            for (int i = 0; i < _questions.Count; i++)
            {
                Button btt_question = new Button { Content = (i + 1).ToString(), Tag = _questions[i]};
                btt_question.Click += Btt_question_Click;
                questionPanel.Children.Add(btt_question);
            }
        
             
            question_control.SetAnswer(_questions[0]);
        }

        private void Btt_question_Click(object sender, RoutedEventArgs e)
        {
            question_control.Clear();
            question_control.SetAnswer((sender as Button).Tag as Question);
        }
    }
}
