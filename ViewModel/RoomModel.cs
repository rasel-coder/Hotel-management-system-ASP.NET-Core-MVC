using HotelApp.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.ViewModel
{
    public class RoomModel
    {
        public int RoomID { get; set; }
        public int? RoomNumber { get; set; }
        public int? RoomTypeID { get; set; }
        public string RoomType { get; set; }
        public string Available { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RoomImages> RoomImages { get; set; }
    }
}
