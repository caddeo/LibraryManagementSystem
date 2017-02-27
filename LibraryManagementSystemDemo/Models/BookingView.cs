using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMSService.Models;

namespace LibraryManagementSystemDemo.Models
{
    public class BookingView
    {
        public Guid Id { get; set; }
     
        public Guid BookId { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Loan until")]
        public DateTime LoanUntil { get; set; }

        public BookingView(Loan loan)
        {
            this.Id = loan.Id;
            this.BookId = loan.Book.Id;
            this.FirstName = loan.Renter.FirstName;
            this.LastName = loan.Renter.LastName;
        }

        public BookingView() { }
    }
}