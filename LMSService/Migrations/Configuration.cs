using System.Collections.Generic;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryMSContext msContext)
        {
            //(localdb)\mssqllocaldb	
            // sqllocaldb 
            // Create books
            var baseUrl =
                @"~/Images/";
            var books = new List<Book>()
            {
                new Book(
                    name: "Feberfrihed",
                    author: "Sophia Handler (f. 1993)",
                    publisher: "Gyldendal",
                    pages: 94,
                    originaltitle: "Originaludgave: 2017",
                    isbn: "978-87-02-21953-1",
                    genre: "Skønlitteratur",
                    pictureUrl: baseUrl + "feberfrihed.jpg"),

                new Book(
                    name: "Det der er imellem os",
                    author: "Nayomi Munaweera",
                    publisher: "Cicero",
                    pages: 302,
                    originaltitle: "What lies between us",
                    isbn: "978-87-638-4610-3",
                    genre: "Skønlitteratur",
                    pictureUrl: baseUrl + "Det-der-er-imellem-os.jpg"),

                new Book(
                    name: "2084 : verdens ende",
                    author: "Boualem Sansal",
                    publisher: "Turbine",
                    pages: 254,
                    originaltitle: "2084 (fransk)",
                    isbn: "978-87-406-1227-1",
                    genre: "Skønlitteratur",
                    pictureUrl: baseUrl + "2084.jpg"),

                new Book(
                    name: "De blindes land",
                    author: "H. G. Wells",
                    publisher: "Science Fiction Cirklen",
                    pages: 254,
                    originaltitle: "Oversat fra engelsk",
                    isbn: "978-87-406-1227-1",
                    genre: "978-87-93233-17-1",
                    pictureUrl: baseUrl + "De-blindes-land.jpg"),
            };

            if (!msContext.Books.Any())
            {
                // Save them if they do not exist
                foreach (var book in books)
                {
                    msContext.Books.Add(book);
                }

                msContext.SaveChanges();
            }

            // Create a renter
            var renter = new Renter("John", "Doe");

            if (!msContext.Renters.Any())
            {
                msContext.Renters.Add(renter);
                msContext.SaveChanges();
            }

            // Make it loan a book
            var loan = new Loan(books[0], renter, DateTime.Now.AddDays(-10).AddMonths(-2), DateTime.Now.AddMonths(10));


            if (!msContext.Loans.Any())
            {
                msContext.Loans.Add(loan);
                books[0].SetLoanStatus(true);
                msContext.SaveChanges();
            }

            // Create a reserver
            var reserver = new Renter("Jane", "Doe");

            if (msContext.Renters.Count() == 1) 
            {
                msContext.Renters.Add(reserver);
                msContext.SaveChanges();
            }

            // Make it reserve a book that is loaned
            var reservation = new Reservation(books[0], reserver);

            if (!msContext.Reservations.Any())
            {
                msContext.Reservations.Add(reservation);
                msContext.SaveChanges();
            }
        }
    }
}
