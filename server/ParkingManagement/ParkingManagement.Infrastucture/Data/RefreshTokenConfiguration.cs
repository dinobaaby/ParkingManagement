

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Infrastucture.Data
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {

        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("REFRESHTOKE");
            builder.HasOne(r => r.User).WithMany(r => r.RefreshToken).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
