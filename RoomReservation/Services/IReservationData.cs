using System.Collections.Generic;
using RoomReservation.Models;

namespace RoomReservation.Services
{
    public interface IReservationData
    {
        IEnumerable<Room> GetRooms();
        Room UpdateRoom( Room room );
        RoomBooking AddBooking( RoomBooking model );
        void TestMethod();
    }
}