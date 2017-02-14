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
    /// Логика взаимодействия для UCForAdd7.xaml
    /// </summary>
    public partial class UCForAdd7 : UserControl
    {
        public UCForAdd7()
        {
            InitializeComponent();
        }

        public int count = 0;

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                count = Convert.ToInt32(TextBox.Text);
                if (count<0)
                {
                    count = 0;
                }
            }
            catch (Exception exception)
            {
              
            }
        }
    }
}
