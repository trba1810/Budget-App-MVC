namespace Budget_App.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
