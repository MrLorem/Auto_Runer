using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : ModernWindow
    {
        UCForAdd1 ucControl1 = new UCForAdd1();
        UCForAdd2 ucControl2 = new UCForAdd2();
        UCForAdd3 ucControl3 = new UCForAdd3();
        UCForAdd4 ucControl4 = new UCForAdd4();
        UCForAdd5 ucControl5 = new UCForAdd5();
        UCForAdd6 ucControl6 = new UCForAdd6();
        UCForAdd7 ucControl7 = new UCForAdd7();
        List<Task> ls = new List<Task>();
        Task ts = new Task();
        private OutputList otList;
        int step = 0;

        public AddWindow(List<Task> lsList, OutputList outputList)
        {
            InitializeComponent();
            GridMain.Children.Add(ucControl1);
            ls = lsList;
            otList = outputList;
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch (step)
                {
                    case 0:
                        if (ucControl1.taskname!="")
                        {
                            ts.Name = ucControl1.taskname;
                            GridMain.Children.Remove(ucControl1);
                            GridMain.Children.Add(ucControl2);
                            step++;
                        }
                        else
                        {
                            throw new Exception("Имя не может быть пустым!");
                        }
                        break;
                    case 1:
                        if (ucControl2.path!="")
                        {
                            ts.Path = ucControl2.tbFile.Text;
                            GridMain.Children.Remove(ucControl2);
                            GridMain.Children.Add(ucControl3);
                            step++;
                        }
                        else
                        {
                            throw new Exception("Выберите файл!");
                        }
                        break;
                    case 2:
                        ts.Flags = ucControl3.tbFlags.Text;
                        GridMain.Children.Remove(ucControl3);
                        GridMain.Children.Add(ucControl5);
                        step++;
                        break;
                    case 3:
                      
                        if (ucControl5.cicl_chek && !ucControl5.normal_chek)
                        {
                            ts.Cyclically = true;
                            GridMain.Children.Remove(ucControl5);
                            GridMain.Children.Add(ucControl6);
                            step += 2;
                        }
                        else if (ucControl5.normal_chek &&!ucControl5.cicl_chek)
                        {
                            ts.Cyclically = false;
                            GridMain.Children.Remove(ucControl5);
                            GridMain.Children.Add(ucControl4);
                            step++;
                        }
                        else
                        {
                            throw new Exception("Выберите один из типов задачи!");
                        }
                        break;
                    case 4: //дата время для обычного запуска
                        if (ucControl4.DataDateTime.ToString()!= "01.01.0001 0:00:00")
                        {
                            ts.DataDateTime = ucControl4.DataDateTime;
                            ls.Add(ts);
                            Close();
                        }
                        else
                        {
                            throw new Exception("Выберите дату и время!");
                        }
                        break;
                    case 5:  //Переодичность цикличного запуска
                        if (ucControl6.dateTime.Hour!=0 || ucControl6.dateTime.Minute != 0)
                        {
                            var interval = new TimeSpan(ucControl6.dateTime.Hour, ucControl6.dateTime.Minute,0);
                            ts.Interval = ts.Interval + interval;
                            step++;
                            GridMain.Children.Remove(ucControl6);
                            GridMain.Children.Add(ucControl7);
                        }
                        else
                        {
                            throw new Exception("Выберите время цикличной записи!");
                        }

                        break;
                    case 6: //Колличество для цикличного запуска
                        if (ucControl7.count!=0)
                        {
                            ts.Cyclically_count = ucControl7.count;
                            GridMain.Children.Remove(ucControl7);
                            GridMain.Children.Add(ucControl4);
                            step = 4;
                        }
                        else
                        {
                            throw new Exception("Введите коллмчество запусков!");
                        }
                        break;
                        
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddWindow_OnClosing(object sender, CancelEventArgs e)
        {
            otList.OutList();
        }
    }
}
