using DapperLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Examp.ModelView.User.CurrentTest
{
   public class UserCurrentTest_ModelView : INotifyPropertyChanged
    {
        public static DapperLib.Test current_test;
        public UserCurrentTest_ModelView(DapperLib.Test value)
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
    }
}
