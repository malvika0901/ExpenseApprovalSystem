namespace ExpenseApprovalSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ExpenseApprovalSystem.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ExpenseApprovalSystem.Data.ExpenseApprovalSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExpenseApprovalSystem.Data.ExpenseApprovalSystemContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                new User() { Id = 1, Name = "Nandini Singh" },
                new User() { Id = 2, Name = "Punam Singh" },
                new User() { Id = 3, Name = "Kamlesh Kumar Singh" },
                new User() { Id = 4, Name = "Malvika Singh"}
            );

            context.Expenses.AddOrUpdate(x => x.Id,
                new Expense()
                {
                    Id = 1,
                    Amount = 3000,
                    Description = "Lunch",
                    UserId = 1,
                    Status = "Submitted"
                },
                new Expense()
                {
                    Id = 2,
                    Amount = 5000,
                    Description = "Dinner",
                    UserId = 2,
                    Status = "Approved"
                },
                new Expense()
                {
                    Id = 3,
                    Amount = 300,
                    Description = "Uber",
                    UserId = 3,
                    Status = "Submitted"
                },
                new Expense()
                {
                    Id = 4,
                    Amount = 30,
                    Description = "Breakfast",
                    UserId = 4,
                    Status = "Rejected"
                }
                );
        }
    }
}
