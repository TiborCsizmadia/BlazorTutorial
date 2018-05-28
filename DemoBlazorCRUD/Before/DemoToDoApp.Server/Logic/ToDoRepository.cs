using DemoToDoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoToDoApp.Server.Logic
{
    public class ToDoRepository: IToDoRepository
    {
        public List<ToDo> Data { get; set; }

        public ToDoRepository()
        {
            var rng = new Random();
            Data = Enumerable.Range(1, 10).Select(index => new ToDo
            {
                ID = index,
                Date = DateTime.Now.AddDays(index),
                Title = "ToDo"+index,
                Description="Beschreibung "+index
            }).ToList();
        }
    }
}
