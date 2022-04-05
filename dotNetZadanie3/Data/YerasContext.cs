using dotNetZadanie3.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetZadanie3.Data
{
    public class YearsContext : DbContext
    {
        public YearsContext (DbContextOptions options) : base(options) { }
        public DbSet<Years> Years { get; set; }
    }

}
