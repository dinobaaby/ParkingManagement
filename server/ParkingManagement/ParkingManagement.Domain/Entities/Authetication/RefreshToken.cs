

using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Domain.Entities.Authetication
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }

        public string Token { get; set; }
        public bool isActive { get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpiresAt { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        
    }
}
