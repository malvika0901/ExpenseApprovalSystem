using System.ComponentModel.DataAnnotations;

namespace ExpenseApprovalSystem.Models
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        public int Amount { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}