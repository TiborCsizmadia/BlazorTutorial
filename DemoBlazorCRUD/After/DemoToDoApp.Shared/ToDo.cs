using System;
using System.Collections.Generic;
using System.Text;

namespace DemoToDoApp.Shared
{
    public class ToDo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }


        public ToDo()
        {
            ID = 0;
            Title = "";
            Date = DateTime.Now;
            Description = "";
        }

        public override string ToString()
        {
            return "T"+ID.ToString("000") + "-" + Title;
        }
    }
}
