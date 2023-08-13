using Budget_App.Models;

namespace Budget_App.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> GetTransactions();
        Transaction GetTransaction(int id);
        void Delete(Transaction transaction);
        void Update(Transaction transaction);
        void Create(Transaction transaction);
        IQueryable<Transaction> Search(string name);
        IQueryable<Transaction> Filter(int id);
    }
}
