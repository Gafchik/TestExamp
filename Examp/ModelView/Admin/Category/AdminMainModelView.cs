using DapperLib;
using Examp.View.Admin;
using Examp.View.Admin.Category;
using Examp.View.Admin.Test;
using Examp.View.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Examp.ModelView.Admin
{
    public class AdminMainModelView : INotifyPropertyChanged
    {
        public ObservableCollection<Category> Categorys { get; set; }
 
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion
        public AdminMainModelView()
        { InitializeComponen(); }

     
         private void InitializeComponen()
        {
            if (Categorys != null)
                Categorys.Clear();
            Categorys = new ObservableCollection<Category>(Category_Repository.Select().ToList());
            OnPropertyChanged("Categorys");
        }
        private Category selected_item; // Выбраная категория
        public Category Selected_Item
        {
            get { return selected_item; }
            set { selected_item = value; OnPropertyChanged("Selected_Item"); }
        }

        private RelayCommand add; // новая категория
        public RelayCommand Add
        {
            get { return add ?? (add = new RelayCommand(act => 
            {
                var window = new NewCategory();
                window.ShowDialog();
                InitializeComponen();
            })); }
        }
        private RelayCommand dell; // dell категорию
        public RelayCommand Dell
        {
            get { return dell ?? (dell = new RelayCommand(
                act => {
                    if (MessageBox.Show("Удалить категорию?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                    if (Selected_Item != null)
                    { 
                        Category_Repository.Delete(Selected_Item);
                        InitializeComponen(); 
                    }
                    else
                        MessageBox.Show("Нужно выбрать что удалять", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                   
                })); }
        }

        private RelayCommand edit; // Редктировать имя категории 
        public RelayCommand Edit
        {
            get { return edit ?? (edit = new RelayCommand(act => {
                if (Selected_Item != null)
                {
                    var window = new EditCategory(Selected_Item);
                    window.ShowDialog();
                    InitializeComponen();
                }
                else
                    MessageBox.Show("Нужно выбрать что-то", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            })); }
        }

        private RelayCommand _in; // Редктировать имя категории 
        public RelayCommand In
        {
            get
            {
                return _in ?? (_in = new RelayCommand(act => {
                    if (Selected_Item != null)
                    {
                        var window = new TestWindow(Selected_Item);
                        window.Show();
                        (act as Window).Close();
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
                   
                        var window = new MainWindow();
                        window.Show();
                        (act as AdminWindow).Close();                   
                }));
            }
        }
    }
}
