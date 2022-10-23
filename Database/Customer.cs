using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public long? CustomerPhone { get; set; }
        public long? NID { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerContact { get; set; }
        public string OtherAddress { get; set; }
        public string OtherContact { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}
