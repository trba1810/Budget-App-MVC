using System.Transactions;

namespace Budget_App.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransaction(int id);
        void Delete(Transaction transaction);
        void Update(Transaction transaction);
        void Create(Transaction transaction);
    }
}
