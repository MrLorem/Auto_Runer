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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Auto_Runer
{
    /// <summary>
    /// Логика взаимодействия для UCForAdd2.xaml
    /// </summary>
    public partial class UCForAdd2 : UserControl
    {
        public UCForAdd2()
        {
            InitializeComponent();
        }

        public string path = "";

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                tbFile.Text = openFileDialog.FileName;
            }
        }
    }
}
