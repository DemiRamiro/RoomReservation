using RoomReservation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.ViewModel
{
    public class RoomViewModel
    {
        [Required]
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public decimal Rate { get; set; }
        public string RoomStatus { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
