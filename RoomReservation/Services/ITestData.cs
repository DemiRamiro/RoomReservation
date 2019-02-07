using System.Collections.Generic;
using RoomReservation.Models;
using RoomReservation.ViewModel;

namespace RoomReservation.Services
{
    public interface ITestData
    {
        IEnumerable<RoomViewModel> GetRooms();
        RoomBooking RoomDetails( int id );
    }
}