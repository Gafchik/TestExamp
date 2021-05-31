using DapperLib;
using Examp.View.User.Category;
using Examp.View.User.CurrentTest;
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

namespace Examp.ModelView.User.Test
{
   public class UserTest_ModelView : INotifyPropertyChanged
    {
        public static DapperLib.Category current_category;
        public UserTest_ModelView(DapperLib.Category value)
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
                .Where(i => i.Test_Category_ID == current_category.Category_ID));
            OnPropertyChanged("Tests");
        }
        private DapperLib.Test selected_item; // Выбраная категория
        public DapperLib.Test Selected_Item
        {
            get { return selected_item; }
            set { selected_item = value; OnPropertyChanged("Selected_Item"); }
        }

       

        private RelayCommand _in; // Редктировать имя категории 
        public RelayCommand In
        {
            get
            {
                return _in ?? (_in = new RelayCommand(act =>
                {
                    if (MessageBox.Show("Начать тест?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                        return;
                    if (Selected_Item != null)
                    {
                        var window = new UserCurrentTest(Selected_Item);
                        window.Show();
                        (act as UserTestWindow).Close();
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

                    var window = new UserCategoryWindow();
                    window.Show();
                    (act as Window).Close();
                }));
            }
        }
    }
}

