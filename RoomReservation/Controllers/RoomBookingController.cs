using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Models;
using RoomReservation.Services;
using RoomReservation.ViewModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomReservation.Controllers
{
    public class RoomBookingController : Controller
    {
        private IReservationData _reservationData;

        public RoomBookingController( IReservationData reservationData)
        {
            _reservationData = reservationData;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BookRoom(int roomId,decimal roomRate, string roomNo, string roomType)
        {
            ViewBag.RoomId = roomId;
            ViewBag.RoomRate = roomRate;
            ViewBag.RoomNo = roomNo;
            ViewBag.RoomType = roomType;

            return View();
        }

        [HttpPost]
        public IActionResult BookRoom( RoomBoookingViewModel model )
        {
            var newRoomBooking = new RoomBooking();
            if (ModelState.IsValid)
            {
                newRoomBooking.RoomId = model.RoomId;
                newRoomBooking.BookingDateFrom = model.BookingDateFrom;
                newRoomBooking.BookingDateTo = model.BookingDateTo;
                newRoomBooking.BookingStatus = "Reserved";
                newRoomBooking.TotalBill = model.TotalBill;

                _reservationData.AddBooking( newRoomBooking );
            }
            return View();
        }
    }
}
