

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

            builder.Entity<Area>(entity =>
            {
                entity.ToTable("AREA");
                entity.HasKey(a => a.AreaId);
                entity.Property(a => a.AreaName).IsRequired();
                entity.HasOne(e => e.User).WithMany(u => u.Areas).HasForeignKey(a => a.UserId);
            });
            builder.Entity<Slot>(entity =>
            {
                entity.ToTable("SLOT");
                entity.HasKey(s => s.SlotId);
                entity.Property(s => s.SlotName).IsRequired();
                entity.HasOne(s => s.Area).WithMany(a => a.Slots).HasForeignKey(s => s.AreaId).OnDelete(DeleteBehavior.Cascade);
            });


            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
