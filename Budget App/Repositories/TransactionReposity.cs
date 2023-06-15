using Budget_App.Data;
using Budget_App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Transactions;

namespace Budget_App.Repositories
{
    public class TransactionReposity : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionReposity(AppDbContext context)
        {
            this._context = context;
        }

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

        public IQueryable<Transaction> GetTransactions()
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
