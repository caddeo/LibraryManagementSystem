using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LMSService.Database;
using LMSService.Handlers.Commands;
using LMSService.Handlers.Queries;
using LMSService.Models;

namespace LMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        private LibraryContext _database;

        public LibraryService()
        {
            _database = new LibraryContext();
        }

        public async Task<List<Book>> GetAllBooks()
        {
            var handler = new GetAllBooksQueryHandler(_database);
            var books = await handler.GetAllBooks();
            return books;
        }

        public Task BorrowBook(Guid bookId, Guid renterId, DateTime from, DateTime to)
        {
            var handler = new BookToRenterCommandHandler(_database);
            handler.Handle(bookId, renterId, from, to);
            return Task.FromResult(0);
        }

        public Task ReserveBook(Guid renterId, Guid bookId)
        {
            var handler = new ReserveToRenterCommandHandler(_database);
            handler.Handle(renterId, bookId);
            return Task.FromResult(0);
        }

        public async Task<Guid> CreateRenter(string firstname, string lastname)
        {
            var handler = new CreateRenterCommandHandler(_database);
            var id = await handler.Handle(firstname, lastname);
            return id;
        }
    }
}
