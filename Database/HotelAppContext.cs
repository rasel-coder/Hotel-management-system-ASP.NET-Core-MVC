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
    }
}
