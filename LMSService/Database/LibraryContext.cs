using System.Data.Entity;
using LMSService.Models;

namespace LMSService.Database
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Renter> Renters { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
