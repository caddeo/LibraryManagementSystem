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
        private LibraryContext _database;

        public GetAllBooksQueryHandler()
        {
            _database = new LibraryContext();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _database.Books.ToListAsync();
        }
    }
}
