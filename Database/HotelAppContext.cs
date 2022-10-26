using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext(DbContextOptions<HotelAppContext> option) : base(option)
        { }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<RoomType> RoomType { get; set; }
        public DbSet<RoomImages> RoomImages { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Balance> Balance { get; set; }
        public DbSet<Booking> Booking { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<MoneyBack> MoneyBack { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<PaymentTran> PaymentTran { get; set; }
    }
}
