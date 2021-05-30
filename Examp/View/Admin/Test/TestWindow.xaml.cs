using Examp.ModelView.Admin.Test;
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

namespace Examp.View.Admin.Test
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private DapperLib.Category category;
        public TestWindow(DapperLib.Category value)
        {
            InitializeComponent();
            category = value;
            DataContext = new TestWindow_ModelView(category);
        }
    }
}
