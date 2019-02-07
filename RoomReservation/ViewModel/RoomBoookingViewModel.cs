using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.ViewModel
{
    public class RoomBoookingViewModel
    {
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string BookingStatus { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public decimal TotalBill { get; set; }
    }
}
