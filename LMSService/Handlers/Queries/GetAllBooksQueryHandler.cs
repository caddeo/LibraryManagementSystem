using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Handlers.Queries
{
    public class GetAllBooksQueryHandler
    {
        private LibraryMSContext _database;

        public GetAllBooksQueryHandler(LibraryMSContext db)
        {
            _database = db;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            using (var db = _database)
            {
                return await db.Books.ToListAsync();
            }
        }
    }
}
