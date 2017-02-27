using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Models
{
    [DataContract]
    public class Loan
    {
        [DataMember]
        public Guid Id { get; protected set; }
        [DataMember]
        public Book Book { get; protected set; }
        [DataMember]
        public Renter Renter { get; protected set; }
        [DataMember]
        public DateTime From { get; protected set; }
        [DataMember]
        public DateTime To { get; protected set; }

        public Loan(Book book, Renter renter, DateTime from, DateTime to)
        {
            this.Id = Guid.NewGuid();
            this.Book = book;
            this.Renter = renter;

            this.From = from;
            this.To = to;
        }

        public Loan() { }
    }
}
