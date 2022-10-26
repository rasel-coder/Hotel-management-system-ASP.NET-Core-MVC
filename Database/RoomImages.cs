using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class RoomImages
    {
        public RoomImages()
        {
            RoomImage = "~/image/default.png";
        }

        [Key]
        public int ImageID { get; set; }
        public int? RoomID { get; set; }
        public string RoomImage { get; set; }
        public virtual Room Room { get; set; }
    }
}
