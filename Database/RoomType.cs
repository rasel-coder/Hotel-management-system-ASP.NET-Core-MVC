using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class RoomType
    {
        [Key]
        public int RoomTypeID { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? BasePrice { get; set; }
        public int? MaxPersonAccept { get; set; }
        public int FeatureID { get; set; }
        public Feature Feature { get; set; }
        public string Description { get; set; }
    }
}
