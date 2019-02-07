using Microsoft.AspNetCore.Identity;

namespace RoomReservation.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}