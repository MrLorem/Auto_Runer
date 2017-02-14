using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace Auto_Runer
{
    class RunThread
    {
        private List<Task> listTasks;

        public RunThread(ref List<Task> ls)
        {
            listTasks = ls;
        }

        public void Run()
        {
            try
            {
                while (true)
                {
                    foreach (var tsk in listTasks.ToArray())
                    {
                        if (!tsk.WasLaunched) //если не был запущен
                           
                        {
                            if (tsk.DataDateTime.Hour == Date_Time.CurrentTimeAndDateTime().Hour &&
                           tsk.DataDateTime.Minute == Date_Time.CurrentTimeAndDateTime().Minute &&
                           tsk.DataDateTime.Day == Date_Time.CurrentTimeAndDateTime().Day &&
                           tsk.DataDateTime.Hour == Date_Time.CurrentTimeAndDateTime().Hour &&
                           tsk.DataDateTime.Month == Date_Time.CurrentTimeAndDateTime().Month &&
                           tsk.DataDateTime.Year == Date_Time.CurrentTimeAndDateTime().Year)
                            {
                                if (tsk.Cyclically) //если цикличный
                                {
                                    if (tsk.Cyclically_count != 0)
                                    {
                                        tsk.Cyclically_count--;
                                        Process.Start(tsk.Path, tsk.Flags);
                                        //tsk.DataDateTime. 
                                        var interval = new TimeSpan(tsk.Interval.Hour,
                                            tsk.Interval.Minute, 0);
                                        tsk.DataDateTime = tsk.DataDateTime + interval;
                                    }
                                    else
                                    {
                                        tsk.WasLaunched = true;
                                    }
                                }
                                else //если одиночный запуск
                                {
                                    Process.Start(tsk.Path, tsk.Flags);
                                    tsk.WasLaunched = true;
                                }
                            }
                            else
                            {
                                tsk.Error = 1;
                            }

                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message != "Поток находился в процессе прерывания.")
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
