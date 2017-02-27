using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Handlers.Commands
{
    public class CreateRenterCommandHandler
    {
        public LibraryContext _database;

        public CreateRenterCommandHandler(LibraryContext db)
        {
            _database = db;
        }

        public async Task<Guid> Handle(string firstname, string lastname)
        {
            var renter = new Renter(firstname, lastname);

            _database.Renters.Add(renter);
            await _database.SaveChangesAsync();

            return renter.Id;
        }
    }
}
