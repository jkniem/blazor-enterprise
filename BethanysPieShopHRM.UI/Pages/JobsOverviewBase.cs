using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.UI.Pages
{
    public class JobsOverviewBase: ComponentBase
    {
        [Inject]
        public IJobDataService JobService { get; set; }

        public List<Job> Jobs { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Jobs = (await JobService.GetAllJobs()).ToList();
        }

        //protected async Task RemoveJob(int jobId)
        //{

        //}

    }
}
