using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Database
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }
        public int? RoomNumber { get; set; }
        public int? RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
        public string Available { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RoomImages> RoomImages { get; set; }
        //public virtual ICollection<Review> Reviews { get; set; }
        //public virtual ICollection<Booking> Bookings { get; set; }

    }
}
