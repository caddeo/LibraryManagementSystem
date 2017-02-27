using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagementSystemDemo.Models
{
    public class BookView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; } 
        public int Pages { get; set; }
        public string OriginalTitle { get; set; }
        public string ISBN { get; set; }
        public string Genre { get; set; } 
        public string PictureURL { get; set; }
        public bool IsReserved { get; set; }

        public BookView(LibraryService.Book book)
        {
            this.Id = book.Id;
            this.Name = book.Name;
            this.Author = book.Author;
            this.Publisher = book.Publisher;
            this.Pages = book.Pages;
            this.OriginalTitle = book.OriginalTitle;
            this.ISBN = book.ISBN;
            this.Genre = book.Genre;
            this.PictureURL = book.PictureURL;
            this.IsReserved = book.IsReserved;
        }
    }
}