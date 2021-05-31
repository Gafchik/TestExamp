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

namespace Examp.View.User.CurrentTest
{
    /// <summary>
    /// Логика взаимодействия для UserCurrentTest.xaml
    /// </summary>
    public partial class UserCurrentTest : Window 
    {

        DispatcherTimer _timer;
        TimeSpan _time;

        public DapperLib.Test test;
        public UserCurrentTest(DapperLib.Test value)
        {
            InitializeComponent();
            test = value;                   
            Test_L.Content = value.Test_Name;

            _time = TimeSpan.FromMinutes(1);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                Timer_L.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero)
                { 
                    _timer.Stop();
                    MessageBox.Show("Время вышло");
                }
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
           
        }

       
    }
}
