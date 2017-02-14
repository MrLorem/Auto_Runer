using FirstFloor.ModernUI.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Auto_Runer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {
        public List<Task> ls = new List<Task>();
        private RunThread runThread;
        private OutputList outputList;
        private Thread Run;

        public MainWindow()
        {
            InitializeComponent();
            SaveAndLoad.load(ref ls);
            outputList = new OutputList(listBox, ls);
            outputList.OutList();
            runThread = new RunThread(ref ls);
            Run = new Thread(runThread.Run);
            Run.Start();

        }

        //Нажатие кнопки добавить
        private void Image_add_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                AddWindow winTask = new AddWindow(ls, outputList);
                winTask.ShowDialog();
                lblFlags.Content = "";
                lblName.Content = "";
                lblPath.Content = "";
                lblbTime.Content = "";
                lblSost.Content = "";
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
            }

        }

        //Нажатие кнопки удалить
        private void Image_dell_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (ls.Remove(ls[listBox.SelectedIndex]))
                {
                    lblFlags.Content = "";
                    lblName.Content = "";
                    lblPath.Content = "";
                    lblbTime.Content = "";
                    lblSost.Content = "";
                    lblCkl.Content = "";
                    lblInterval.Content = "";
                    lblData.Content = "";
                    lblError.Content = "";
                    outputList.OutList();
                }
            }
            catch (Exception exception)
            {
                
                MessageBox.Show(exception.Message);
            }
        }

        //Выбран элемент в листбоксе
        private void ListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex!=-1)
            try
            {
                lblName.Content = ls[listBox.SelectedIndex].Name;
                lblPath.Content = ls[listBox.SelectedIndex].Path;
                lblbTime.Content = ls[listBox.SelectedIndex].DataDateTime.Hour+":"+ls[listBox.SelectedIndex].DataDateTime.Minute;
                lblData.Content = ls[listBox.SelectedIndex].DataDateTime.Day + "." +
                                  ls[listBox.SelectedIndex].DataDateTime.Month + "." +
                                  ls[listBox.SelectedIndex].DataDateTime.Year;
                if (ls[listBox.SelectedIndex].WasLaunched)
                {
                    lblSost.Content = "Был запущен";
                }
                else
                if (ls[listBox.SelectedIndex].Error==0)
                {
                    lblSost.Content = "В очереди на выполнение";
                }
                else
                {
                        lblSost.Content = "Ошибка";
                    if (ls[listBox.SelectedIndex].Error == 1)
                    {
                            lblError.Content = "Ошибка 1 : программа не работала в нужный моммент";
                    }
                    if (ls[listBox.SelectedIndex].Error == 2)
                    {
                            lblError.Content = "Ошибка 2 : файл не найден";
                        }
                }
              
                if (ls[listBox.SelectedIndex].Flags=="")
                {
                    lblFlags.Content = "Нету";
                }
                    else
                    {
                        lblFlags.Content = ls[listBox.SelectedIndex].Flags;
                    }
                    if (ls[listBox.SelectedIndex].Cyclically)
                {
                    lblCkl.Content = "Да";
                    lblInterval.Content = ls[listBox.SelectedIndex].Interval.Hour +":"+
                                          ls[listBox.SelectedIndex].Interval.Minute;
                        
                }
                else
                {
                    lblCkl.Content = "Нет";
                }
           
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        //Закрытие программы
        private void MainWindow_OnClosed(object sender, EventArgs e)
        {
            try
            {
                SaveAndLoad.save(ref ls); //Сохраняем список задач
                Run.Abort(); //Закрываем второй поток
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
         
        }

  
    }
}
