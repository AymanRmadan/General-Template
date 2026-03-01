using System.Reflection;

namespace GeneralTemplate.DAL.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            var user = new ApplicationUser
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "ayman",
                NormalizedUserName = "AYMAN",
                Email = "admin.com",
                NormalizedEmail = "ADMIN.COM",
                EmailConfirmed = true,
                FirstName = "Ayman",
                LastName = "Ramadan",
                SecurityStamp = "11111111-1111-1111-1111-111111111111",
                ConcurrencyStamp = "22222222-2222-2222-2222-222222222222",
                IsDisabled = false,

                PasswordHash = "AQAAAAEAACcQAAAAEExampleStaticHashHere123456=="
            };

            builder.Entity<ApplicationUser>().HasData(user);


            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

        }
    }
}