using System;
using Microsoft.AspNetCore.Identity;


namespace RoomReservation.Data
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public string IpAddress { get; set; }
    }
}