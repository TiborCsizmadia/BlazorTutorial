using DemoToDoApp.Client.Services;
using DemoToDoApp.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoToDoApp.Client.Pages
{
    public class CreateToDoViewModel : BlazorComponent
    {
        
        public ToDo DataItem { get; set; }

        [Inject]
        protected IToDoClientRepository repository { get; set; }
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        protected override void OnInit()
        {
            DataItem = new ToDo();
        }

        public async void CreateToDo()
        {
            await repository.CreateAsync(DataItem);

            UriHelper.NavigateTo("/todoes");
        }

    }
}
