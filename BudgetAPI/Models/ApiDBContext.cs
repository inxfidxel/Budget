using Microsoft.EntityFrameworkCore;

namespace BudgetAPI.Models
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options){}

        public DbSet<Bill> Bills { get; set; }
    }
}