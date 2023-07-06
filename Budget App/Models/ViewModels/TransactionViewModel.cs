namespace Budget_App.Models.ViewModels
{
    public class TransactionViewModel
    {
        public IQueryable<Transaction> Transactions { get; set; }

        public Transaction Transaction { get; set; }
    }
}
