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
        public LibraryMSContext _database;

        public CreateRenterCommandHandler(LibraryMSContext db)
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
