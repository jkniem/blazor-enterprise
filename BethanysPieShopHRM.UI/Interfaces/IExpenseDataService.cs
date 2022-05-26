using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.Shared;

namespace BethanysPieShopHRM.UI.Interfaces
{ 
    public interface IExpenseDataService
    {
        public Task<IEnumerable<Expense>> GetAllExpenses();
        public Task<Expense> GetExpenseById(int id);
        public Task<IEnumerable<Currency>> GetAllCurrencies();
        public Task<Expense> AddExpense(Expense editExpense);
        public Task UpdateExpense(Expense editExpense);
    }
}
