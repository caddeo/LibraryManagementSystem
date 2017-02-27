using System.Collections.Generic;
using LMSService.Database;
using LMSService.Models;

namespace LMSService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LibraryContext context)
        {
            var baseUrl =
                "C:\\Users\\poss_\\Documents\\visual studio 2015\\Projects\\LibraryManagementSystemDemo\\LibraryMSService\\Images\\";
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
                    pictureURL: baseUrl + "feberfrihed.jpg"),

                new Book(
                    name: "Det der er imellem os",
                    author: "Nayomi Munaweera",
                    publisher: "Cicero",
                    pages: 302,
                    originaltitle: "What lies between us",
                    isbn: "978-87-638-4610-3",
                    genre: "Skønlitteratur",
                    pictureURL: baseUrl + "Det-der-er-imellem-os.jpg"),

                new Book(
                    name: "2084 : verdens ende",
                    author: "Boualem Sansal",
                    publisher: "Turbine",
                    pages: 254,
                    originaltitle: "2084 (fransk)",
                    isbn: "978-87-406-1227-1",
                    genre: "Skønlitteratur",
                    pictureURL: baseUrl + "2084.jpg"),
            };

            foreach (var book in books)
            {
                if (!context.Books.Any(x => x.Id == book.Id))
                {
                    context.Books.Add(book);
                }
            }

            context.SaveChanges();

            var reservation = new Reservation(books[0], "Jon Doe");

            if (!context.Reservations.Any(x => x.Id == reservation.Id))
            {
                context.Reservations.Add(reservation);
                context.SaveChanges();
            }


        }
    }
}
