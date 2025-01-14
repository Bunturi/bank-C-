using Bank.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base
            (options)
        {

        }

        public virtual DbSet<Expends> Expend { get; set; }

    }
}
