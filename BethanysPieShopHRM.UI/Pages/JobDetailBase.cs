using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class JobDetailBase : ComponentBase
    {
        [Inject]
        public IJobDataService JobDataService { get; set; }

        [Parameter]
        public int Id { get; set; }
       
        public Job Job { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Job = await JobDataService.GetJobById(Id);
        }
    }
}
