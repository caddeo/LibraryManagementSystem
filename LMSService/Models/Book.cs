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
        public string PictureURL { get; set; }
        [DataMember]
        public bool IsReserved { get; protected set; }

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

            this.IsReserved = false;
        }

        // Overload
        public Book(string name, string author, string publisher, int pages, string originaltitle, string isbn,
            string genre, string pictureURL) : this(name, author, publisher, pages, originaltitle, isbn, genre)
        {
            SetPictureURL(pictureURL);
        }
        public Book() : this(string.Empty, string.Empty, string.Empty, 0, string.Empty, string.Empty, string.Empty) {}

        public void SetPictureURL(string absolutePath)
        {
            this.PictureURL = absolutePath;
        }

        public void SetReservedStatus(bool status)
        {
            this.IsReserved = status;
        }
    } 
}
