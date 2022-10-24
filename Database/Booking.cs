using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int? RoomNum { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? DailyPrice { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalPrice { get; set; }
        public bool? IsPaid { get; set; }
    }
}
