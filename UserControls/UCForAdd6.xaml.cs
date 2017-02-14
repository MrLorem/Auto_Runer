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
    /// Логика взаимодействия для UCForAdd6.xaml
    /// </summary>
    public partial class UCForAdd6 : UserControl
    {
        public UCForAdd6()
        {
            InitializeComponent();
        }

       public   DateTime dateTime = new DateTime();
        private void TimePicker_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                dateTime = DateTime.Parse(TimePicker.Text);
            }
            catch (Exception exception)
            {
              
            }
           
        }

    }
}
