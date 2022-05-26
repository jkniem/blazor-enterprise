using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Interfaces
{
    public interface IExpenseApprovalService
    {
       Task<ExpenseStatus> GetExpenseStatus(Expense expense);
    }
}