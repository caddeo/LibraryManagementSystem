using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Handlers.Commands
{
    public class BookToRenterCommandHandler
    {
        private LibraryMSContext _database;
        public BookToRenterCommandHandler(LibraryMSContext db)
        {
            _database = db;
        }

        // Book book, Renter renter, DateTime from, DateTime to
        public async void Handle(Guid bookId, Guid renterId, DateTime from, DateTime to)
        {
            // Extra security
            var book = _database.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                return;
            }

            var renter = _database.Renters.FirstOrDefault(x => x.Id == renterId);

            var loan = new Loan(book, renter, from, to);
            _database.Loans.AddOrUpdate(loan);

            book.SetLoanStatus(true);
            _database.Books.AddOrUpdate(book);
            await _database.SaveChangesAsync();
        }
    }
}
