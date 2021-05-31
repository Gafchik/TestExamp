using DapperLib;
using Examp.View.Admin.Answer;
using Examp.View.Admin.Question;
using Examp.View.Admin.Test;
using Examp.View.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Examp.ModelView.Admin.Question
{
    public class QuestionWindow_ModelView : INotifyPropertyChanged
    {
        private DapperLib.Test current_test;
        public QuestionWindow_ModelView(DapperLib.Test value)
        {
            current_test = value;
            InitializeComponen();
        }
        public ObservableCollection<DapperLib.Question> Questions { get; set; }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion     


        private void InitializeComponen()
        {
            if (Questions != null)
                Questions.Clear();
            Questions = new ObservableCollection<DapperLib.Question>(Question_Repository.Select().ToList()
                .Where(i => i.Question_Test_ID == current_test.Test_ID));
            OnPropertyChanged("Questions");
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
                    var window = new NewQuestion(current_test);
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

                    var window = new TestWindow(TestWindow.category);
                    window.Show();
                    (act as Window).Close();
                }));
            }
        }

        private RelayCommand _in; // Редктировать имя категории 
        public RelayCommand In
        {
            get
            {
                return _in ?? (_in = new RelayCommand(act =>
                {
                    if (Selected_Item != null)
                    {
                        var window = new AnswerWindow(Selected_Item);
                        window.Show();
                        (act as QuestionWindow).Close();
                    }
                    else
                        MessageBox.Show("Нужно выбрать что-то", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }));
            }
        }
    }
}
