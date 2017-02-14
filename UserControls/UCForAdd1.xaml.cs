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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UCForAdd1 : UserControl
    {
        public UCForAdd1()
        {
            InitializeComponent();
        }

       public string taskname = "";

        private void TbTaskName_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                taskname = TbTaskName.Text;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
