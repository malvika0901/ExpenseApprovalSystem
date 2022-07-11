﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ExpenseApprovalSystem.Data;
using ExpenseApprovalSystem.Models;

namespace ExpenseApprovalSystem.Controllers
{
    public class ExpensesController : ApiController
    {
        private ExpenseApprovalSystemContext db = new ExpenseApprovalSystemContext();

        // GET: api/Expenses
        public IQueryable<Expense> GetExpenses()
        {
            return db.Expenses;
        }

        // GET: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> GetExpense(int id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expenses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutExpense(int id, Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expense.Id)
            {
                return BadRequest();
            }

            db.Entry(expense).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Expenses
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> PostExpense(Expense expense)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Expenses.Add(expense);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [ResponseType(typeof(Expense))]
        public async Task<IHttpActionResult> DeleteExpense(int id)
        {
            Expense expense = await db.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            db.Expenses.Remove(expense);
            await db.SaveChangesAsync();

            return Ok(expense);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExpenseExists(int id)
        {
            return db.Expenses.Count(e => e.Id == id) > 0;
        }
    }
}