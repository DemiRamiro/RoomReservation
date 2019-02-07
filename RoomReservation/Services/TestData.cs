using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomReservation.Models;
using RoomReservation.ViewModel;

namespace RoomReservation.Services
{
    public class TestData : ITestData
    {
        List<RoomViewModel> _rooms;
        List<RoomBooking> _roomBookings;
        public TestData()
        {
            _rooms = new List<RoomViewModel>
            {
                new RoomViewModel(){ RoomId = 1, RoomNo = "101", RoomType = "Single", Rate = 2000.00M, RoomStatus = "Reserved"},
                new RoomViewModel(){ RoomId = 2, RoomNo = "102", RoomType = "Single", Rate = 2000.00M, RoomStatus = "Paid" },
                new RoomViewModel(){ RoomId = 3, RoomNo = "103", RoomType = "Double", Rate = 3000.00M, RoomStatus = "Reserved"},
                new RoomViewModel(){ RoomId = 4, RoomNo = "104", RoomType = "Double", Rate = 3000.00M, RoomStatus = "Available"},
                new RoomViewModel(){ RoomId = 5, RoomNo = "105", RoomType = "Family", Rate = 5000.00M, RoomStatus = "Available"},
            };

            _roomBookings = new List<RoomBooking>
            {
                new RoomBooking()
                {
                    BookingId = 1,
                    BookingDateFrom = Convert.ToDateTime("12-29-2018"),
                    BookingDateTo = Convert.ToDateTime("12-30-2018"),
                    BookingStatus = "Reserved",
                    TotalBill = 2000.00M,
                    RoomId = 1
                },
                new RoomBooking()
                {
                    BookingId = 2,
                    BookingDateFrom = Convert.ToDateTime("12-29-2018"),
                    BookingDateTo = Convert.ToDateTime("12-30-2018"),
                    BookingStatus = "Paid",
                    TotalBill = 2000.00M,
                    RoomId = 2
                },
                new RoomBooking()
                {
                    BookingId = 3,
                    BookingDateFrom = Convert.ToDateTime("12-29-2018"),
                    BookingDateTo = Convert.ToDateTime("12-30-2018"),
                    BookingStatus = "Reserved",
                    TotalBill = 2000.00M,
                    RoomId = 3
                },
                new RoomBooking()
                {
                    BookingId = 4,
                    BookingDateFrom = Convert.ToDateTime("12-29-2018"),
                    BookingDateTo = Convert.ToDateTime("12-30-2018"),
                    BookingStatus = "Reserved",
                    TotalBill = 2000.00M,
                    RoomId = 4
                },
                new RoomBooking()
                {
                    BookingId = 5,
                    BookingDateFrom = Convert.ToDateTime("12-29-2018"),
                    BookingDateTo = Convert.ToDateTime("12-30-2018"),
                    BookingStatus = "Reserved",
                    TotalBill = 2000.00M,
                    RoomId = 5
                }
            };
        }

        public IEnumerable<RoomViewModel> GetRooms()
        {
            var rooms = from r in _rooms select r;
            return rooms;
        }

        public RoomBooking RoomDetails(int id)
        {
            return _roomBookings.Where( r => r.RoomId == id ).Single();
        }
    }
}
