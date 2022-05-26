using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;
using BethanysPieShopHRM.UI.Interfaces;

namespace BethanysPieShopHRM.UI.Services
{
    public class ManagerExpenseApprovalService : IExpenseApprovalService
    {
        private readonly IEmployeeDataService _employeeDataService;

        public ManagerExpenseApprovalService(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public async Task<ExpenseStatus> GetExpenseStatus(Expense expense)
        {
            var employee = await _employeeDataService.GetEmployeeDetails(expense.EmployeeId);

            if (expense.Amount <= 20)
            {
                return ExpenseStatus.Approved;
            }

            if (!employee.IsFTE)
            {
                if (expense.ExpenseType != ExpenseType.Training)
                {
                    return ExpenseStatus.Denied;
                }
            }

            if (expense.ExpenseType == ExpenseType.Food && expense.Amount > 100)
            {
                return ExpenseStatus.Pending;
            }

            if (expense.Amount > 5000)
            {
                return ExpenseStatus.Pending;
            }

            if (employee.IsOPEX)
            {
                switch (expense.ExpenseType)
                {
                    case ExpenseType.Conference:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Transportation:
                        return ExpenseStatus.Denied;
                    case ExpenseType.Hotel:
                        return ExpenseStatus.Denied;
                }
            }

            return ExpenseStatus.Pending;
        }
    }
}
