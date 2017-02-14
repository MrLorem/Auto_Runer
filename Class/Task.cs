using System;

namespace Auto_Runer
{
    //Класс задачи для листа
    public class Task
    {
        public DateTime DataDateTime = new DateTime();
        public bool Cyclically { get; set; } = false;
        public DateTime Interval = new DateTime();
        public string Path { get; set; } = "";
        public string Name { get; set; } = "";
        public bool WasLaunched { get; set; } = false;
        public string Flags { get; set; } = "";
        public int Cyclically_count { get; set; } = 0;
        public int Error { get; set; } = 0;
    }
}
