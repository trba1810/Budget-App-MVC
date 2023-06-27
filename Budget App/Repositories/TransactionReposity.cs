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
            _context.Transactions.Add(transaction);
        }

        public void Delete(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Include(x=>x.Category).Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Transaction> GetTransactions()
        {
            return _context.Transactions.Include(x => x.Category).AsQueryable();
        }

        public void Update(Transaction transaction)
        {
            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public Transaction Search(string name)
        {
            return _context.Transactions.Include(x => x.Category).Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
