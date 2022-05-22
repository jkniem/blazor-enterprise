using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Services;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class TaskListBase : ComponentBase
    {
        [Inject]
        public ITaskDataService TaskService { get; set; }

        [Inject]
        public NavigationManager NavManager { get; set; }

        [Parameter]
        public int Count { get; set; }

        public List<HRTask> Tasks { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Tasks = (await TaskService.GetAllTasks()).ToList();

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
