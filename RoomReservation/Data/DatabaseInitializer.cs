using RoomReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.Data
{
    public static class DatabaseInitializer
    {
        public static void Initialize( ReservationDbContext context )
        {
            context.Database.EnsureCreated();
            if (!context.Rooms.Any())
            {
                var rooms = new Room()
                {
                    RoomNo = "101",
                    RoomStatus = "Available",
                    RoomType = "Single",
                    Rate = 2000.00M
                };

                context.Rooms.Add( rooms );
                context.SaveChanges();

                rooms = new Room()
                {
                    RoomNo = "102",
                    RoomStatus = "Available",
                    RoomType = "Single",
                    Rate = 3000.00M
                };

                context.Rooms.Add( rooms );
                context.SaveChanges();

                rooms = new Room()
                {
                    RoomNo = "103",
                    RoomStatus = "Available",
                    RoomType = "Double",
                    Rate = 4000.00M
                };

                context.Rooms.Add( rooms );
                context.SaveChanges();

                rooms = new Room()
                {
                    RoomNo = "104",
                    RoomStatus = "Available",
                    RoomType = "Family",
                    Rate = 8000.00M
                };

                context.Rooms.Add( rooms );
                context.SaveChanges();

                rooms = new Room()
                {
                    RoomNo = "105",
                    RoomStatus = "Available",
                    RoomType = "Double",
                    Rate = 4000.00M
                };

                context.Rooms.Add( rooms );
                context.SaveChanges();
            }
        }
    }
}
