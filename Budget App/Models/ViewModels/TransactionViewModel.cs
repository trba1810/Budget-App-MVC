namespace Budget_App.Models.ViewModels
{
    public class TransactionViewModel
    {
        public Transaction Transaction { get; set; }
        public IQueryable<Transaction> Transactions { get; set; }

        public IQueryable<Category> Categories { get; set; }

    }
}
