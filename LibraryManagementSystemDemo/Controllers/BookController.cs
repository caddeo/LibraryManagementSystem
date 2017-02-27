using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystemDemo.LibraryService;
using LibraryManagementSystemDemo.Models;
using LMSService.Models;

namespace LibraryManagementSystemDemo.Controllers
{
    public class BookController : Controller
    {
        private LibraryServiceClient _service;

        public BookController()
        {
            _service = new LibraryServiceClient();

        }

        // GET: BookView
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAllBooksAsync();
            var books = model
                .Select(book => new BookView(book))
                .ToList();
            return View(books);
        }

        [HttpGet]
        public ActionResult Reserve(string id)
        {
            var model = new ReservationView() { BookId =  new Guid(id) };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SendReserve(ReservationView reservation)
        {
            if (!ModelState.IsValid)
            {
                return View("Reserve", reservation);
            }

            var renter = await _service.CreateRenterAsync(reservation.FirstName, reservation.LastName);
            await _service.ReserveBookAsync(renter, reservation.BookId);

            ViewBag.Status = "Successfully rented book";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult LoanOut(string id)
        {
            var model = new BookingView() {BookId = new Guid(id)};
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> SendLoanOut(BookingView booking)
        {
            if (!ModelState.IsValid)
            {
                return View("LoanOut", booking);
            }

            var renter = await _service.CreateRenterAsync(booking.FirstName, booking.LastName);
            await _service.BorrowBookAsync(booking.BookId, renter, DateTime.Now, booking.LoanUntil);

            return RedirectToAction("Index");
        }
    }
}