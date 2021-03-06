﻿using System;
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
        public Renter Renter { get; protected set; }

        public Reservation(Book book, Renter renter)
        {
            this.Id = Guid.NewGuid();

            this.Book = book;
            this.Renter = renter;
        }

        // Overload
        public Reservation() : this(null, null) {  }
    }
}
