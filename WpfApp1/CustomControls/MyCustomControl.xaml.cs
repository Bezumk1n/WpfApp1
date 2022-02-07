﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.CustomControls;
using WpfApp1.Models;

namespace WpfApp1.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для MyCustomControl.xaml
    /// </summary>
    public partial class MyCustomControl : UserControl
    {
        public MyCustomControl()
        {
            InitializeComponent();
            SetCommands();
        }
    }
}
