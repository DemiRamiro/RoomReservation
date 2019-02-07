using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.Models
{
    public class RoomBooking
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int BookingId { get; set; }
        public int RoomId { get; set; }
        public string BookingStatus { get; set; }
        public DateTime BookingDateFrom { get; set; }
        public DateTime BookingDateTo { get; set; }
        public decimal TotalBill { get; set; }
    }
}
