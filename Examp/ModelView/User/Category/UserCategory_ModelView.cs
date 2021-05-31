using DapperLib;
using Examp.View.Admin;
using Examp.View.User.Test;
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

namespace Examp.ModelView.User.Category
{
   public class UserCategory_ModelView : INotifyPropertyChanged
    {
        public ObservableCollection<DapperLib.Category> Categorys { get; set; }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged; // ивент обновления
        public void OnPropertyChanged([CallerMemberName] string prop = "")
           => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        #endregion
        public UserCategory_ModelView()
        { InitializeComponen(); }


        private void InitializeComponen()
        {
            if (Categorys != null)
                Categorys.Clear();
            Categorys = new ObservableCollection<DapperLib.Category>(Category_Repository.Select().ToList());
            OnPropertyChanged("Categorys");
        }
        private DapperLib.Category selected_item; // Выбраная категория
        public DapperLib.Category Selected_Item
        {
            get { return selected_item; }
            set { selected_item = value; OnPropertyChanged("Selected_Item"); }
        }

        

        private RelayCommand _in; // Редктировать имя категории 
        public RelayCommand In
        {
            get
            {
                return _in ?? (_in = new RelayCommand(act => {
                    if (Selected_Item != null)
                    {
                        var window = new UserTestWindow(Selected_Item);
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
