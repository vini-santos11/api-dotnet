using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Database
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Person> Persons { get; set; }
    }
}
