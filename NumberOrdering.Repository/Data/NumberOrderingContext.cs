using Microsoft.EntityFrameworkCore;
using NumberOrdering.Repository.Models;

namespace NumberOrdering.Repository.Data
{
    public class NumberOrderingContext : DbContext
    {
        public NumberOrderingContext(DbContextOptions<NumberOrderingContext> options): base(options)
        {
        }

        public DbSet<Number> Numbers { get; set; }
    }
}
