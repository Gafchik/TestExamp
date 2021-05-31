﻿using Examp.ModelView.User.Category;
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

namespace Examp.View.User.Category
{
    /// <summary>
    /// Логика взаимодействия для UserCategoryWindow.xaml
    /// </summary>
    public partial class UserCategoryWindow : Window
    {
        public UserCategoryWindow()
        {
            InitializeComponent();
            DataContext = new UserCategory_ModelView();
        }
    }
}
