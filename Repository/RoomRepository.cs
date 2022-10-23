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
    public class RoomRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> AddOrEditRoom(RoomModel model)
        {
            if (model.RoomID == 0)
            {
                var room = new Room()
                {
                    RoomID = model.RoomID,
                    RoomNumber = model.RoomNumber,
                    RoomTypeID = model.RoomTypeID,
                    Available = model.Available,
                    Description = model.Description
                };
                await _context.Room.AddAsync(room);
            }
            else
            {
                var room = _context.Room.Find(model.RoomID);
                room.RoomID = model.RoomID;
                room.RoomNumber = model.RoomNumber;
                room.RoomTypeID = model.RoomTypeID;
                room.Available = model.Available;
                room.Description = model.Description;
                _context.Update(room);
            }
            await _context.SaveChangesAsync();
            return model.RoomID;
        }

        public async Task<RoomModel> GetRoomById(int id)
        {
            return await _context.Room.Where(x => x.RoomID == id)
                .Select(room => new RoomModel()
                {
                    RoomID = room.RoomID,
                    RoomNumber = room.RoomNumber,
                    RoomTypeID = room.RoomTypeID,
                    RoomType = room.RoomType.Name,
                    Available = room.Available,
                    Description = room.Description
                }).FirstOrDefaultAsync();
        }

        public async Task<List<RoomModel>> GetAllRooms()
        {
            var rooms = new List<RoomModel>();
            var allRooms = await(from x in _context.Room
                                 join y in _context.RoomType 
                                 on x.RoomTypeID equals y.RoomTypeID
                                      select new
                                      {
                                          x.RoomID,
                                          x.RoomNumber,
                                          y.Name,
                                          x.Available,
                                          x.Description
                                      }).ToListAsync();
            if (allRooms?.Any() == true)
            {
                foreach (var room in allRooms)
                {
                    rooms.Add(new RoomModel()
                    {
                        RoomID = room.RoomID,
                        RoomNumber = room.RoomNumber,
                        RoomType = room.Name,
                        Available = room.Available,
                        Description = room.Description
                    });
                }
            }
            return rooms;
        }
    }
}
