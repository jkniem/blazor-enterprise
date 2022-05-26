using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Interfaces
{
    public interface IJobDataService
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJobById(int jobId);
        Task AddJob(Job newJob);
        Task UpdateJob(Job updatedJob);
        Task DeleteJob(int jobId);
    }
}