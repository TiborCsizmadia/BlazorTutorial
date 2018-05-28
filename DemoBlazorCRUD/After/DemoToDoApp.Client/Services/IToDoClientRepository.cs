using DemoToDoApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoToDoApp.Client.Services
{
    public interface IToDoClientRepository
    {
        List<ToDo> Data { get; set; }

        Task RefreshDataAsync();
        Task CreateAsync(ToDo myToDo);
        Task EditAsync(ToDo myToDo);
        Task DeleteAsync(ToDo myToDo);
    }
}
