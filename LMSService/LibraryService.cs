using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LMSService.Handlers.Queries;
using LMSService.Models;

namespace LMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LibraryService" in both code and config file together.
    public class LibraryService : ILibraryService
    {
        public Task<List<Book>> GetAllBooks()
        {
            var handler = new GetAllBooksQueryHandler();
            var books = handler.GetAllBooks();
            return books;
        }
    }
}
