using Microsoft.AspNetCore.Mvc.Rendering;

namespace Budget_App.Models.ViewModels
{
    public class TransactionViewModel
    {
        public Transaction Transaction { get; set; }
        public List<Transaction> Transactions { get; set; }

        public List<Category> Categories { get; set; }


    }
}
