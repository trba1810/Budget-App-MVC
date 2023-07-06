using Budget_App.Models;
using Budget_App.Models.ViewModels;
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
            TransactionViewModel vm = new TransactionViewModel();
            vm.Transactions = transactions;
            return View(vm);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var transaction = _transactionRepository.GetTransaction(id);
            if (transaction == null)
            {
                return NotFound();
            }
            _transactionRepository.Delete(transaction);
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
