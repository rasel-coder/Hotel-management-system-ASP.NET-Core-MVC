using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
        public int? Floor { get; set; }
        public int? Room { get; set; }
    }
}
