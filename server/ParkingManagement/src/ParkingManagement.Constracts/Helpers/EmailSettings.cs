﻿

namespace ParkingManagement.Constracts.Helpers
{
    public class EmailSettings
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public int Port { get; set; }
    }
}
