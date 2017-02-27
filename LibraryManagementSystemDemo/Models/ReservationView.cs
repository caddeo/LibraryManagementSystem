using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LMSService.Models;

namespace LibraryManagementSystemDemo.Models
{
    public class ReservationView
    {
        public Guid Id { get; set; }
     
        public Guid BookId { get; set; }

        [Display(Name = "First name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required]
        public string LastName { get; set; }

        public ReservationView(Reservation reservation)
        {
            this.Id = reservation.Id;
            this.BookId = reservation.Book.Id;
            this.FirstName = reservation.Renter.FirstName;
            this.LastName = reservation.Renter.LastName;
        }

        public ReservationView() { }
    }
}