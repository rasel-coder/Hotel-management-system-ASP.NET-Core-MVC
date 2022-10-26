using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.ViewModel
{
    public class RoomImagesModel
    {
        public RoomImagesModel()
        {
            RoomImage = "~/image/default.png";
        }

        public int ImageID { get; set; }
        public int? RoomID { get; set; }
        public int? RoomNumber { get; set; }
        public string RoomImage { get; set; }
        public IFormFile RoomImageUpload { get; set; }
    }
}
