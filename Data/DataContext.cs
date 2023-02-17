using Microsoft.EntityFrameworkCore;

namespace testapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<testmodel> empl { get; set; }
    }
}
