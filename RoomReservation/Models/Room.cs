using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservation.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public decimal Rate { get; set; }
        public string RoomStatus { get; set; }
    }
}
