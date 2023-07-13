using Budget_App.Models;
using Budget_App.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            
            return View(transactions);
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
            var trans = _transactionRepository.GetTransaction(id);
            return View("Edit",trans);
        }

        [HttpPut("{id}")] 
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

        [HttpGet]
        public IActionResult Search(string name) 
        { 
            var transactions = _transactionRepository.Search(name);
            return RedirectToAction("Index",transactions);
        }
    }
}
