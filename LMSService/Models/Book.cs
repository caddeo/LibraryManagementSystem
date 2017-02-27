using System;
using System.Runtime.Serialization;

namespace LMSService.Models
{
    [DataContract]
    public class Book : IBook
    {
        [DataMember]
        public Guid Id { get; protected set; }
        [DataMember]
        public string Name { get; protected set; }
        [DataMember]
        public string Author { get; protected set; } // .
        [DataMember]
        public string Publisher { get; protected set; } // .
        [DataMember]
        public int Pages { get; protected set; }
        [DataMember]
        public string OriginalTitle { get; protected set; }
        [DataMember]
        public string ISBN { get; protected set; }
        [DataMember]
        public string Genre { get; protected set; } // .
        [DataMember]
        public string PictureUrl { get; set; }

        [DataMember]
        public bool IsLendOut { get; protected set; }

        public Book(string name, string author, string publisher, int pages, string originaltitle, string isbn, string genre)
        {
            this.Id = Guid.NewGuid();

            this.Name = name;
            this.Author = author;
            this.Publisher = publisher;
            this.Pages = pages;
            this.OriginalTitle = originaltitle;
            this.ISBN = isbn;
            this.Genre = genre;

            this.IsLendOut = false;
        }

        // Overload
        public Book(string name, string author, string publisher, int pages, string originaltitle, string isbn,
            string genre, string pictureUrl) : this(name, author, publisher, pages, originaltitle, isbn, genre)
        {
            SetPictureURL(pictureUrl);
        }
        public Book() : this(string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty) {}

        public void SetPictureURL(string absolutePath)
        {
            this.PictureUrl = absolutePath;
        }

        public void SetLoanStatus(bool status)
        {
            this.IsLendOut = status;
        }
    } 
}
