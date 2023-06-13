using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_App.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
