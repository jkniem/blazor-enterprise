using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace BethanysPieShopHRM.UI.Pages
{
    public class TaskListBase : ComponentBase
    {
        [Inject]
        public ITaskDataService TaskService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Inject]
        public ILogger<TaskListBase> Logger { get; set; }

        [Parameter]
        public int Count { get; set; }

        public List<HRTask> Tasks { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Tasks = (await TaskService.GetAllTasks()).ToList();
            }
            catch(Exception ex)
            {
                Logger.LogDebug(ex, ex.Message);
            }

            if (Count != 0)
            {
                Tasks = Tasks.Take(Count).ToList();
            }
        }

        public void AddTask()
        {
            NavManager.NavigateTo("taskedit");
        }
    }
}
