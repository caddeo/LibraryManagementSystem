using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using LMSService.Models;

namespace LMSService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILibraryService" in both code and config file together.
    [ServiceContract]
    public interface ILibraryService
    {
        // Queries
        [OperationContract]
        Task<List<Book>> GetAllBooks();

        // Commands 
        [OperationContract]
        Task BorrowBook(Guid bookId, Guid renterId, DateTime from, DateTime to);

        [OperationContract]
        Task ReserveBook(Guid renterId, Guid bookId);

        [OperationContract]
        Task<Guid> CreateRenter(string firstname, string lastname);
    }
}
