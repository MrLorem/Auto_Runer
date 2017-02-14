using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Auto_Runer
{
   public static class SaveAndLoad
    {

        public static void save(ref List<Task> listTasks)
        {
            string output = JsonConvert.SerializeObject(listTasks); //сериализуем в json
            var fd=  File.Create(AppDomain.CurrentDomain.BaseDirectory + @"tasks.json");
            fd.Close();
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + @"tasks.json", output); //пишем в файл
        }

        public static void load(ref List<Task> listTasks)
        {
            FileStream file1 = new FileStream(AppDomain.CurrentDomain.BaseDirectory + @"tasks.json", FileMode.Open); //создаем файловый поток
            StreamReader reader = new StreamReader(file1);
            string str = reader.ReadToEnd(); //читаем файл до конца
            reader.Close();
            listTasks = JsonConvert.DeserializeObject<List<Task>>(str); //десериализуем
        }

    }
}
