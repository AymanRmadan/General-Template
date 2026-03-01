using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeneralTemplate.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.OwnsMany(u => u.RefreshTokens).ToTable("RefreshTokens")
                .WithOwner().HasForeignKey("UserId");

            builder.Property(u => u.FirstName).HasMaxLength(100);
            builder.Property(u => u.LastName).HasMaxLength(100);


            //Default Seed Data

            var passwordHasher = new PasswordHasher<ApplicationUser>();
        }
    }
}
