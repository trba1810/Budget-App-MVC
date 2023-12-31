﻿using Budget_App.Data;
using Budget_App.Models;
using Budget_App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Budget_App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.Include(x => x.Transaction);
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
