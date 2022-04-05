using dotNetZadanie3.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetZadanie3.Data
{
    public class PeopleContext : DbContext
    {
        public DbSet<Years> Years { get; set; }
    }

}
