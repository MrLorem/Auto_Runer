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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Auto_Runer
{
    /// <summary>
    /// Логика взаимодействия для UserControl5.xaml
    /// </summary>
    public partial class UCForAdd5 : UserControl
    {
        public UCForAdd5()
        {
            InitializeComponent();
        }

        public bool cicl_chek;
        public bool normal_chek;

        private void CheckBox_normal_OnChecked(object sender, RoutedEventArgs e)
        {
            normal_chek = true;
        }

        private void CheckBox_normal_OnUnchecked(object sender, RoutedEventArgs e)
        {
            normal_chek = false;
        }

        private void CheckBox_cil_OnChecked(object sender, RoutedEventArgs e)
        {
            cicl_chek = true;
        }

        private void CheckBox_cil_OnUnchecked(object sender, RoutedEventArgs e)
        {
            cicl_chek = false;
        }
    }
}
