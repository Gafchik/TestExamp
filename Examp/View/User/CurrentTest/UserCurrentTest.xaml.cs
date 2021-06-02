using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using DapperLib;
using Examp.View.User.Test;

namespace Examp.View.User.CurrentTest
{
    /// <summary>
    /// Логика взаимодействия для UserCurrentTest.xaml
    /// </summary>
    public partial class UserCurrentTest : Window 
    {
        private struct Selected_Answer
        {
            public int Id_Question { get; set; }
            public int Id_Ansver { get; set; }
        }
 
        List<Selected_Answer> selected_answers = new List<Selected_Answer>(); // коллекция выбраных ответов
   
        public Question Current_Question; // текущий вопрос
      
        List<Question> _questions; // лист со всеми вопросами теста
        DispatcherTimer _timer; // таймер
        TimeSpan _time; // время для таймера

        public DapperLib.Test test;  // текущий тест   
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
                    CheckRezult();
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start(); // старт таймера

            _questions = Question_Repository.Select().ToList().FindAll(i => i.Question_Test_ID == test.Test_ID);
            for (int i = 0; i < _questions.Count; i++)
            {
                Button btn_question = new Button { Content = (i + 1).ToString(),Height = 20,Width=50, Tag = _questions[i]};
                btn_question.Click += Btn_question_Click;
                questionPanel.Children.Add(btn_question);
            }

            Current_Question = _questions[0];
            question_control.SetAnswer(_questions[0]);
        }

        private void Btn_question_Click(object sender, RoutedEventArgs e) // переключение между вопросами
        {
            question_control.Clear();
            question_control.SetAnswer((sender as Button).Tag as Question);
            Current_Question = (sender as Button).Tag as Question;
        }

        private void reply_btn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Ответить", "Если вы ответите\n вы больше не сможете изменить ответ?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                return;
            question_control.checks.FindAll(i => i.IsChecked.Value). // запоминаем ответ
                ForEach(i => selected_answers.Add(new Selected_Answer
                {
                    Id_Question = Current_Question.Question_ID,
                    Id_Ansver = (i.Tag as Answer).Answer_ID
                }));
            foreach (var item in questionPanel.Children) // выключаем отвеченый вопрос
            {
                if (item is Button)
                    if ((item as Button).Tag as Question == Current_Question)
                        (item as Button).IsEnabled = false;
            }
            int cout_enable_btn = 0;
            foreach (var item in questionPanel.Children) // проверяем есть ли еще вопросы
            {
                if (item is Button)
                    if ((item as Button).IsEnabled == true)
                        cout_enable_btn++;
            }
            if (cout_enable_btn == 0)
                CheckRezult();
        }

        private void CheckRezult()
        {
            List<Selected_Answer> all_true_answers = new List<Selected_Answer>();
            int count_all_true_answer = 0;
            int count_true_answer = 0;
            // поиск всех правельных ответов
            _questions.ForEach(i => Answer_Repository.Select().ToList()
            .FindAll(q => q.Answer_Question_ID == i.Question_ID)
            .FindAll(q => q.Answer_True != 0).ForEach(q=> all_true_answers.Add(new Selected_Answer
             {
                Id_Ansver=q.Answer_ID,
                Id_Question =i.Question_ID
            })));
            // подсчет совпавших ответов
            foreach (var item in all_true_answers)
            {
                if (selected_answers.Exists(i => i.Id_Question == item.Id_Question))
                    if (selected_answers.Exists(i => i.Id_Ansver == item.Id_Ansver))
                        count_true_answer++;
            }
            int rezult = 12 / all_true_answers.Count * count_true_answer;
            MessageBox.Show($"Выш результат :\nВсего ответов: {all_true_answers.Count}\nПравельных ответов: {count_true_answer}\n Оценка: {rezult}",
                "Тест пройден", MessageBoxButton.OK);
            var window = new UserTestWindow(UserTestWindow.category);
            Close();
            window.Show();
        }
    }
}
