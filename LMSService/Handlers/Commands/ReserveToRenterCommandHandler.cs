using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Handlers.Commands
{
    public class ReserveToRenterCommandHandler
    {
        private LibraryContext _database;

        public ReserveToRenterCommandHandler(LibraryContext db)
        {
            _database = db;
        }

        public async void Handle(Guid renterId, Guid bookId)
        {
            var renter = _database.Renters.FirstOrDefault(x => x.Id == renterId);

            if (renter == null)
            {
                return;
            }

            var book = _database.Books.FirstOrDefault(x => x.Id == bookId);

            if (book == null)
            {
                return;
            }

            var reservation = new Reservation(book, renter);
            _database.Reservations.Add(reservation);
            await _database.SaveChangesAsync();
        }
    }
}
