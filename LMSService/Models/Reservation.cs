using System;
using System.Runtime.Serialization;

namespace LMSService.Models
{
    [DataContract]
    public class Reservation
    {
        [DataMember]
        public Guid Id { get; protected set; }
        [DataMember]
        public Book Book { get; protected set; }
        [DataMember]
        public string PersonDetails { get; protected set; } //.

        public Reservation(Book book, string persondetails)
        {
            this.Id = Guid.NewGuid();

            this.Book = book;
            this.PersonDetails = persondetails;
        }
    }
}
