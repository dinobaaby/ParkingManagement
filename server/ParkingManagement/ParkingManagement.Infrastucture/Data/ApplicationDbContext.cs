

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Domain.Entities;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Infrastucture.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Slot> Slot { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<Vehicle> Vehicles {  get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("USERS");
                e.Property(e => e.Id).HasMaxLength(150);
            });
            builder.Entity<IdentityRole>().ToTable("ROLES");
            builder.Entity<IdentityUserRole<string>>().ToTable("USERROLE");
            builder.Entity<IdentityUserClaim<string>>().ToTable("USERCLAIM");
            builder.Entity<IdentityUserLogin<string>>().ToTable("USERLOGIN");
            builder.Entity<IdentityUserToken<string>>().ToTable("USERTOKEN");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ROLECLAIM");


        
           


       
     

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
