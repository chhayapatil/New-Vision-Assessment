using Microsoft.EntityFrameworkCore;
namespace UserDemo.Models
{
    public class DataAccess : DbContext
    {
        public DataAccess(DbContextOptions<DataAccess> options)
            : base(options)
        { }

        public DbSet<User> User { get; set; }
    }
}
