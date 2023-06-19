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
            return View(_transactionRepository.GetTransactions());
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
    }
}
