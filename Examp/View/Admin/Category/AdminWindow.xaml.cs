using Examp.ModelView.Admin;
using System.Windows;

namespace Examp.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            DataContext = new AdminMainModelView();
        }

        
    }
}
