using Budget_App.Repositories.Interfaces;
using System.Transactions;

namespace Budget_App.Repositories
{
    public class TransactionReposity : ITransactionRepository
    {
        public void Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public void Delete(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Transaction GetTransaction(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
