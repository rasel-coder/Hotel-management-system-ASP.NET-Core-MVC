using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.ViewModel
{
    public class RoomTypeModel
    {
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        public decimal? BasePrice { get; set; }
        public int? MaxPersonAccept { get; set; }
        public int FeatureID { get; set; }
        public string Feature { get; set; }
        public string Description { get; set; }
    }
}
