using Budget_App.Data;
using Budget_App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using Budget_App.Models;

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
            return _context.Transactions.Include(x => x.Category).AsQueryable();
        }

        public void Update(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
