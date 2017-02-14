using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для UCForAdd4.xaml
    /// </summary>
    public partial class UCForAdd4 : UserControl
    {
        public UCForAdd4()
        {
            InitializeComponent();
        }

        public DateTime DataDateTime = new DateTime();
        private void DatePicker_OnCalendarClosed(object sender, RoutedEventArgs e)
        {
            try
            {
                DataDateTime = DateTime.Parse(DatePicker.Text);
            }
            catch (Exception exception)
            {
               
            }
           
        }

        private void TimePicker_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            try
            {
                DataDateTime = DateTime.Parse(TimePicker.Text);
            }
            catch (Exception exception)
            {
         
            }
          
        }
    }
}
