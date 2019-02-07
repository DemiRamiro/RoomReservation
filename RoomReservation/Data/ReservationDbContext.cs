using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoomReservation.Models;

namespace RoomReservation.Data
{
    public class ReservationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ReservationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomBooking> RoomBookings { get; set; }
    }
}