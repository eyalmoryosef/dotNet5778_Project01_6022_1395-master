﻿using System;
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

namespace UI.child
{
    /// <summary>
    /// Interaction logic for childMenu.xaml
    /// </summary>
    public partial class childMenu : Window
    {
        public childMenu()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Window add = new addChildWindow();
            add.Show();
        }
    }
}
