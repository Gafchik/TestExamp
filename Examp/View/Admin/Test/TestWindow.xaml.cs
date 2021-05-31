using Examp.ModelView.Admin.Test;
using System.Windows;

namespace Examp.View.Admin.Test
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public static DapperLib.Category category;
        public TestWindow(DapperLib.Category value)
        {
            InitializeComponent();
            category = value;
            DataContext = new TestWindow_ModelView(category);
        }
    }
}
