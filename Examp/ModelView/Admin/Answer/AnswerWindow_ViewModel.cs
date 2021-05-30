using DapperLib;
using Examp.View.Admin.Answer;
using Examp.View.Admin.Question;
using Examp.View.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Examp.ModelView.Admin.Answer
{
   public class AnswerWindow_ViewModel : INotifyPropertyChanged
    {
        private DapperLib.Question current_question;
        public AnswerWindow_ViewModel(DapperLib.Question value)
        {
            current_question = value;
            InitializeComponen();
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion

        public ObservableCollection<DapperLib.Answer> Answers { get; set; }
        private void InitializeComponen()
        {
            if (Answers != null)
                Answers.Clear();
            Answers = new ObservableCollection<DapperLib.Answer>(Answer_Repository.Select().ToList()
                .Where(i => i.Answer_Question_ID == current_question.Question_ID));
            OnPropertyChanged("Answers");
        }
        private DapperLib.Question selected_item; // Выбраная категория
        public DapperLib.Question Selected_Item
        {
            get { return selected_item; }
            set { selected_item = value; OnPropertyChanged("Selected_Item"); }
        }

        private RelayCommand add; // новая категория
        public RelayCommand Add
        {
            get
            {
                return add ?? (add = new RelayCommand(act =>
                {
                    var window = new NewAnswer(current_question);
                    window.ShowDialog();
                    InitializeComponen();
                }));
            }
        }
        private RelayCommand dell; // dell категорию
        public RelayCommand Dell
        {
            get
            {
                return dell ?? (dell = new RelayCommand(
              act =>
              {
                  if (MessageBox.Show("Удалить категорию?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                      return;
                  if (Selected_Item != null)
                  {
                      Question_Repository.Delete(Selected_Item);
                      InitializeComponen();
                  }
                  else
                      MessageBox.Show("Нужно выбрать что удалять", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

              }));
            }
        }

        private RelayCommand edit; // Редктировать имя категории 
        public RelayCommand Edit
        {
            get
            {
                return edit ?? (edit = new RelayCommand(act =>
                {
                    if (Selected_Item != null)
                    {
                        var window = new EditQuestion(Selected_Item);
                        window.ShowDialog();
                        InitializeComponen();
                    }
                    else
                        MessageBox.Show("Нужно выбрать что-то", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }));
            }
        }
        private RelayCommand back;
        public RelayCommand Back
        {
            get
            {
                return back ?? (back = new RelayCommand(act =>
                {

                    var window = new QuestionWindow(QuestionWindow.test);
                    window.Show();
                    (act as Window).Close();
                }));
            }
        }   
    }
}
