using DemoToDoApp.Client.Services;
using DemoToDoApp.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoToDoApp.Client.Pages
{
    public class ToDoesViewModel : BlazorComponent
    {
        public ToDo[] todoes { get; set; }

        [Inject]
        protected IToDoClientRepository repository { get; set; }

        public ToDoesViewModel()
        {
            todoes = null;
        }

        protected override async Task OnInitAsync()
        {
            await repository.RefreshDataAsync();
            todoes = repository.Data.ToArray();
        }
    }
}
