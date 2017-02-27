using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LMSService.Models
{
    [DataContract]
    public class Renter
    {
        [DataMember]
        public Guid Id { get; protected set; }
        [DataMember]
        public string FirstName { get; protected set; }
        [DataMember]
        public string LastName { get; protected set; }

        public Renter(string firstname, string lastname)
        {
            this.Id = Guid.NewGuid();
            this.FirstName = firstname;
            this.LastName = lastname;
        }

        public Renter() { }
    }
}
