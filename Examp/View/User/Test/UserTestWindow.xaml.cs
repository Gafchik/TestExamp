using Examp.ModelView.User.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Examp.View.User.Test
{
    /// <summary>
    /// Логика взаимодействия для UserTestWindow.xaml
    /// </summary>
    public partial class UserTestWindow : Window
    {
        public static DapperLib.Category category;
        public UserTestWindow(DapperLib.Category value)
        {
            InitializeComponent();
            category = value;
            DataContext = new UserTest_ModelView(category);
        }
    }
}
