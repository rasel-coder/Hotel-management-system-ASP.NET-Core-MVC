using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public int? PaymentMethod { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? BookingId { get; set; }
        public Booking Booking { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
