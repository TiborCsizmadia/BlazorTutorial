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
    public class EditToDoViewModel : BlazorComponent
    {
        [Parameter]
        private string ID { get; set; }

        public ToDo DataItem { get; set; }

        [Inject]
        protected IToDoClientRepository repository { get; set; }
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        protected override void OnInit()
        {
                       
            int myID = int.Parse(ID);
            DataItem = repository.Data.FirstOrDefault(x => x.ID ==myID);
        }

        public async void SaveToDo()
        {
            await repository.EditAsync(DataItem);

            UriHelper.NavigateTo("/todoes");
        }

    }
}
