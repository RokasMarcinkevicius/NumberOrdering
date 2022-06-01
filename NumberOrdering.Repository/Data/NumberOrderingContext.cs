using Microsoft.EntityFrameworkCore;
using NumberOrdering.Repository.Models;

namespace NumberOrdering.Repository.Data
{
    internal class NumberOrderingContext : DbContext
    {
        public DbSet<Number> Numbers { get; set; }
    }
}
