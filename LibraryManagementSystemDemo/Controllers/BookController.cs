using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystemDemo.LibraryService;
using LibraryManagementSystemDemo.Models;

namespace LibraryManagementSystemDemo.Controllers
{
    public class BookController : Controller
    {
        private LibraryServiceClient _service;
        private List<Book> _allBooks;

        public BookController()
        {
            _service = new LibraryServiceClient();
            
            //

        }
        // GET: BookView
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllBooksAsync();
            var books = model
                .Select(book => new BookView(book))
                .ToList();
            return View(books);
        }
    }
}