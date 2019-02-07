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
    public class RoomController : Controller
    {
        private IReservationData _reservationData;
        public RoomController( IReservationData reservationData )
        {
            _reservationData = reservationData;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var rooms = new RoomViewModel();
            rooms.Rooms = _reservationData.GetRooms().ToList();

            return View( rooms );
        }

        [HttpGet]
        public IActionResult EditRoom( int roomId, string roomNo )
        {
            ViewData["RoomId"] = roomId;
            ViewData["RoomNo"] = roomNo;
            return View();
        }

        [HttpPost]
        public IActionResult EditRoom( RoomViewModel model )
        {
            Room room = new Room();
            if (ModelState.IsValid)
            {
                room.RoomId = model.RoomId;
                room.RoomNo = model.RoomNo;
                room.RoomType = model.RoomType;
                room.RoomStatus = "Available";
                room.Rate = model.Rate;

                _reservationData.UpdateRoom( room );
                return RedirectToAction( nameof( Index ) );
            }
            else
            {
                return View();
            }
        }

        //[HttpGet]
        //public IActionResult Details( int id, string roomNo )
        //{
        //    var roomBooking = new RoomBooking();
        //    ViewBag.RoomNo = roomNo;
        //    roomBooking = _reservationData.( id );
        //    return View( roomBooking );
        //}

    }
}
