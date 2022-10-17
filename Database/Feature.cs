using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Feature
    {
        public Feature()
        {
            Icon = "~/image/default.png";
        }

        [Key]
        public int FeatureID { get; set; }
        public string FeatureName { get; set; }
        public string Icon { get; set; }
        [NotMapped]
        public IFormFile IconUpload { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
    }
}
