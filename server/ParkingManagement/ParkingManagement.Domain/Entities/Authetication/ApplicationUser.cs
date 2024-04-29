

using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Domain.Entities.Authetication
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(150)]
        public override string Id { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string CardId { get; set; } = null!;

        [Required]
        [Range(0, 10)]
        [DefaultValue(1)]
        public int UserStatus { get; set; }

        public ICollection<RefreshToken>? RefreshToken { get; set; }
        public virtual ICollection<Area>? Areas { get; set; }
        
    }

   
}
