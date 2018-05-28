using DemoToDoApp.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoToDoApp.Client.Services
{
    public class ToDoClientRepository: IToDoClientRepository
    {
        
        private HttpClient Http { get; set; }

        public ToDoClientRepository(HttpClient myHttp)
        {
            Http = myHttp;
        }

        public List<ToDo> Data { get; set; }

        public async Task RefreshDataAsync()
        {            
            ToDo[] myDataArray = await Http.GetJsonAsync<ToDo[]>("/api/ToDoes");

            Data = myDataArray.ToList();
        }

        public async Task CreateAsync(ToDo myToDo)
        {
            await Http.PostJsonAsync("/api/ToDoes", myToDo);
        }

        public async Task EditAsync(ToDo myToDo)
        {
            await Http.PutJsonAsync("/api/ToDoes/"+myToDo.ID, myToDo);
        }

        public async Task DeleteAsync(ToDo myToDo)
        {
            await Http.DeleteAsync("/api/ToDoes/"+myToDo.ID);
        }
    }
}
