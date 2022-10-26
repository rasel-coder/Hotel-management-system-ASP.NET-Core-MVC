using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.ViewModel
{
    public class BookingModel
    {
        public int BookingId { get; set; }
        public int? RoomNum { get; set; }

        [DataType(DataType.Date)]
        public string FromDate { get; set; }

        [DataType(DataType.Date)]
        public string ToDate { get; set; }
        public int? CustomerId { get; set; }
        public string Customer { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? DailyPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }
        public string IsPaid { get; set; }
    }
}
