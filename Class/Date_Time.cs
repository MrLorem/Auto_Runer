using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Auto_Runer
{
    public static class Date_Time
    {

        //Получаем время вормата Час/Минута
        public static DateTime CurrentTimeAndDateTime()
        {
            try
            {
                return DateTime.Now;
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message);
                return DateTime.Now;
            }
         
        }

        ////Получаем дату формата Год/Месяц/День
        //public static string CurrentDate()
        //{
        //    try
        //    {   string str = DateTime.Now.Day.ToString("d2") + "." + DateTime.Now.Month.ToString("d2") + "." + DateTime.Now.Year;
        //        return str;
        //    }
        //    catch (Exception exception)
        //    {

        //        MessageBox.Show(exception.Message);
        //        return null;
        //    }
          
        //}
    }
}
