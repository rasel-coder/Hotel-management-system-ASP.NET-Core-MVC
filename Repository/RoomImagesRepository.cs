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
    public class RoomImagesRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomImagesRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<RoomImagesModel> GetRoomImagesById(int id)
        {
            return await _context.RoomImages.Where(x => x.RoomID == id)
                .Select(roomImage => new RoomImagesModel()
                {
                    ImageID = roomImage.ImageID,
                    RoomNumber = roomImage.Room.RoomNumber,
                    RoomImage = roomImage.RoomImage
                }).FirstOrDefaultAsync();
        }

        public async Task<int> AddOrEditRoomImages(RoomImagesModel model)
        {

            if (model.RoomID != 0)
            {
                var addRoomImages = new RoomImages()
                {
                    RoomID = model.RoomID,
                    RoomImage = model.RoomImage
                };
                await _context.RoomImages.AddAsync(addRoomImages);
            }
                
            else
            {
                RoomImages editRoomImages = new RoomImages();
                editRoomImages.RoomID = model.RoomID;
                editRoomImages.RoomImage = model.RoomImage;
                _context.RoomImages.Update(editRoomImages);
            }
            await _context.SaveChangesAsync();
            return model.RoomID;
        }


    }
}
