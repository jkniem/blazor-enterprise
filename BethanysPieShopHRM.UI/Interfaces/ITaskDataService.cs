using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Interfaces
{
    public interface ITaskDataService
    {
        Task<IEnumerable<HRTask>> GetAllTasks();
        Task<HRTask> GetTaskById(int taskId);
        Task<HRTask> AddTask(HRTask task);
    }
}
