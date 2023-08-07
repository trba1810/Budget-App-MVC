using Budget_App.Models;
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

        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var transactions = _transactionRepository.GetTransactions();
            TransactionViewModel vm = new TransactionViewModel();
            vm.Transactions = transactions.ToList();
            return View(vm);
        }

        [HttpGet]
        public IActionResult DeleteWindow(int id)
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
            return View("Create"); 
        }


        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
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
            vm.Categories = _transactionRepository.GetTransactions().Select(x => x.Category).Distinct().ToList();
            var trans = _transactionRepository.GetTransaction(id);
            vm.Transaction = trans;
            return View("Edit",vm);
        }

        [HttpPost("{id}")] 
        public IActionResult Update(int id,Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }
            try
            {
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
            TransactionViewModel tr = new TransactionViewModel();
            //var transactions = _transactionRepository.Search(name);
            tr.Transactions = _transactionRepository.Search(name).ToList();
            return View("Index", tr);
        }
    }
}
