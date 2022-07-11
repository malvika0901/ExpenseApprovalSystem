using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExpenseApprovalSystem.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public int TotalBudget { get; set; }
    }
}