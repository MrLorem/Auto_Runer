using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Auto_Runer
{
   public  class OutputList
   {
       private ListBox listBox;
       private List<Task> listTasks;
       public 
            OutputList(ListBox lb, List<Task> ls)
       {
           this.listBox = lb;
           this.listTasks = ls;
       }

        //Выводим лист в список задач
        public void OutList()
        {
            listBox.Items.Clear();
            foreach (var ts in listTasks)
            {
                Label lbLabe = new Label();
                lbLabe.Content = ts.Name;
                listBox.Items.Add(lbLabe);
            }

      
        }
    }
}
