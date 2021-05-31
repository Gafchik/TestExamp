using DapperLib;
using Examp.View.Admin;
using Examp.View.Admin.Question;
using Examp.View.Admin.Test;
using Examp.View.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Examp.ModelView.Admin.Test
{
    public class TestWindow_ModelView : INotifyPropertyChanged
    {
        private DapperLib.Category current_category;
        public TestWindow_ModelView(DapperLib.Category value)
        {
            current_category = value;
            InitializeComponen();
        }
        public ObservableCollection<DapperLib.Test> Tests { get; set; }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion     


        private void InitializeComponen()
        {
            if (Tests != null)
                Tests.Clear();
            Tests = new ObservableCollection<DapperLib.Test>(Test_Repository.Select().ToList()
                .Where(i=> i.Test_Category_ID == current_category.Category_ID));
            OnPropertyChanged("Tests");
        }
        private DapperLib.Test selected_item; // Выбраная категория
        public DapperLib.Test Selected_Item
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
                    var window = new NewTest(current_category);
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
              act => {
                  if (MessageBox.Show("Удалить категорию?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                      return;
                  if (Selected_Item != null)
                  {
                      Test_Repository.Delete(Selected_Item);
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
                return edit ?? (edit = new RelayCommand(act => {
                    if (Selected_Item != null)
                    {
                        var window = new EditTest(Selected_Item);
                        window.ShowDialog();
                        InitializeComponen();
                    }
                    else
                        MessageBox.Show("Нужно выбрать что-то", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
                        var window = new QuestionWindow(Selected_Item);
                        window.Show();
                        (act as TestWindow).Close();
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
                return back ?? (back = new RelayCommand(act => {

                    var window = new AdminWindow();
                    window.Show();
                    (act as Window).Close();
                }));
            }
        }
    }
}
