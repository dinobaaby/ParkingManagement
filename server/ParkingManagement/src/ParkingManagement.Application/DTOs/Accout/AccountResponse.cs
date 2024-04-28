using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.Application.DTOs.Accout
{
    public class AccountResponse
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email {  get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string CardId { get; set; } = null!;
    }
}
