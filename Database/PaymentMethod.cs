using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string MethodName { get; set; }
    }
}
