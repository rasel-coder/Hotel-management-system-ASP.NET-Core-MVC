using HotelApp.Database;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Repository
{
    public class HotelRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> SaveHotel(HotelModel model)
        {
            if (model.Id == 0)
            {
                var hotel = new Hotel()
                {
                    Floor = model.Floor,
                    Room = model.Room
                };
                await _context.AddAsync(hotel);
            }
            else
            {
                var hotel = _context.Hotel.Find(model.Id);
                hotel.Floor = model.Floor;
                hotel.Room = model.Room;
                _context.Update(hotel);
            }
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task<HotelModel> GetHotelById(int id)
        {
            return await _context.Hotel.Where(x => x.Id == id)
                .Select(hotel => new HotelModel()
                {
                    Id = hotel.Id,
                    Floor = hotel.Floor,
                    Room = hotel.Room
                }).FirstOrDefaultAsync();
        }

        public async Task<List<HotelModel>> GetAllHotels()
        {
            var hotels = new List<HotelModel>();
            var allHotels = await _context.Hotel.ToListAsync();
            if (allHotels?.Any() == true)
            {
                foreach (var hotel in allHotels)
                {
                    hotels.Add(new HotelModel()
                    {
                        Id = hotel.Id,
                        Floor = hotel.Floor,
                        Room = hotel.Room
                    });
                }
            }
            return hotels;
        }
    }
}
