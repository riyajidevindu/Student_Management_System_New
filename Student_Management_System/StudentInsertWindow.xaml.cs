﻿using Student_Management_System;
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

namespace Student_Management_System
{
    /// <summary>
    /// Interaction logic for StudentInsertWindow.xaml
    /// </summary>
    public partial class StudentInsertWindow : Window
    {
        public StudentInsertWindow(StudentInsertWindowVM vm)

        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = () => Close();
        }


    }
}