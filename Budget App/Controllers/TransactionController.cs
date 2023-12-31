﻿using Budget_App.Models;
using Budget_App.Models.ViewModels;
using Budget_App.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Budget_App.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TransactionController(ITransactionRepository transactionRepository, ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var transactions = _transactionRepository.GetTransactions();
            TransactionViewModel vm = new TransactionViewModel();       
            vm.Categories = _categoryRepository.GetCategories().ToList();
            vm.Transactions = transactions.ToList();
            return View(vm);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteWindowTransaction(int id)
        {
            var transaction = _transactionRepository.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            
            return View("Delete", transaction);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var trans = _transactionRepository.GetTransaction(id);
            _transactionRepository.Delete(trans);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateWindow() 
        {
            TransactionViewModel vm = new TransactionViewModel();
            vm.Categories = _categoryRepository.GetCategories().ToList();
            return View("Create",vm); 
        }


        [HttpPost]
        public IActionResult Create(TransactionViewModel vm)
        {
            var transaction = vm.Transaction;
            if (transaction == null)
            {
                return NotFound();
            }
            _transactionRepository.Create(transaction);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            TransactionViewModel vm = new TransactionViewModel();
            vm.Categories = _categoryRepository.GetCategories().ToList();
            var trans = _transactionRepository.GetTransaction(id);
            vm.Transaction = trans;
            return View("Edit",vm);
        }

        [HttpPost] 
        public IActionResult Update(TransactionViewModel vm)
        {
            if (vm.Transaction.Id == 0)
            {
                return BadRequest();
            }
            try
            {
                Transaction transaction = vm.Transaction;
                _transactionRepository.Update(transaction);
            }
            catch
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string name) 
        {
            TransactionViewModel vm = new TransactionViewModel();
            vm.Transactions = _transactionRepository.Search(name).ToList();
            vm.Categories = _categoryRepository.GetCategories().ToList();
            return View("Index", vm);
        }

        [HttpPost]
        public IActionResult Filter(int id)
        {
            TransactionViewModel vm = new TransactionViewModel();
            vm.Transactions = _transactionRepository.Filter(id).ToList();
            vm.Categories = _categoryRepository.GetCategories().ToList();
            return View("Index",vm);
        }
    }
}
