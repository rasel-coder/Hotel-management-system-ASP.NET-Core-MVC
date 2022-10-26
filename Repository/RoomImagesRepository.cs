using HotelApp.Database;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            var data = await _context.RoomImages.Where(x => x.ImageID == id)
                .Select(roomImage => new RoomImagesModel()
                {
                    ImageID = roomImage.ImageID,
                    RoomID = roomImage.RoomID,
                    RoomImage = roomImage.RoomImage
                }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<int> AddOrEditRoomImages(RoomImagesModel model)
        {
            if(model.RoomImageUpload != null)
            {
                string folder = "image/roomImage/";
                folder += Guid.NewGuid().ToString() + model.RoomImageUpload.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                model.RoomImage = "/" + folder;
                await model.RoomImageUpload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
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
            return model.ImageID;
        }

        public async Task<IEnumerable<RoomImagesModel>> GetAllRoomImages()
        {
            var roomImages = new List<RoomImagesModel>();
            var allRoomImages = await (from x in _context.RoomImages
                                       join y in _context.Room
                                       on x.RoomID equals y.RoomID
                                       select new
                                       {
                                           x.ImageID,
                                           x.Room.RoomNumber,
                                           x.RoomImage
                                       }).ToListAsync();
            if (allRoomImages?.Any() == true)
            {
                foreach (var roomImage in allRoomImages)
                {
                    roomImages.Add(new RoomImagesModel()
                    {
                        ImageID = roomImage.ImageID,
                        RoomNumber = roomImage.RoomNumber,
                        RoomImage = roomImage.RoomImage
                    });
                }
            }
            return roomImages;
        }
    }
}
