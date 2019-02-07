using Microsoft.EntityFrameworkCore;
using RoomReservation.Data;
using RoomReservation.Models;
using RoomReservation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.Services
{
    public class ReservationData : IReservationData
    {
        private ReservationDbContext _context;

        public ReservationData( ReservationDbContext context )
        {
            _context = context;
        }

        public IEnumerable<Room> GetRooms()
        {
            var rooms = from r in _context.Rooms select r;
            return rooms;
        }

        public Room UpdateRoom(Room room )
        {
            _context.Attach( room ).State = EntityState.Modified;
            _context.SaveChanges();
            return room;
        }

        public RoomBooking AddBooking(RoomBooking model)
        {
            if(model.RoomId != 0)
            {
                _context.RoomBookings.Add( model );
                _context.SaveChanges();

                var room = _context.Rooms.First( r => r.RoomId == model.RoomId );
                room.RoomStatus = model.BookingStatus;
                _context.SaveChanges();
            }
            return model;
        }

        //public RoomBooking RoomDetails( int id )
        //{
        //    return _context.Database. .Where( r => r.RoomId == id ).Single();
        //}

        public void TestMethod()
        {
        }
    }
}
