using Microsoft.EntityFrameworkCore;
using CustomersAPI.Models;

namespace CustomersAPI.Data
{
    public class CustomerAPIDbContext : DbContext
    {
        public CustomerAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
    }
}
