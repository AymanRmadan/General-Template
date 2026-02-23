

namespace GeneralTemplate.DAL.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<Test> Tests { get; set; }
    }
}
