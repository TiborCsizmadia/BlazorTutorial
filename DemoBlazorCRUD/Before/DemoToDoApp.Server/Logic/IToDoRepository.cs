using DemoToDoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoToDoApp.Server.Logic
{
    public interface IToDoRepository
    {
        List<ToDo> Data { get; set; }
    }
}
