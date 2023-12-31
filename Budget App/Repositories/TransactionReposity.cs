﻿using Budget_App.Data;
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
            _context.SaveChanges();
        }

        public void Delete(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            _context.SaveChanges();
        }

        public Transaction GetTransaction(int id)
        {
            return _context.Transactions.Include(x => x.Category).Where(x => x.Id == id).FirstOrDefault();
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

        public IQueryable<Transaction> Search(string name)
        {
            var search = _context.Transactions.Include(x => x.Category).Where(x => x.Name.Contains(name));
            return search;
        }

        public IQueryable<Transaction> Filter(int id)
        {
            var filter = _context.Transactions.Include(x => x.Category).Where(x => x.CategoryId == id);
            return filter;
        }
    }
}
