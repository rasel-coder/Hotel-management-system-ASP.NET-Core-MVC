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
    public class RoomTypeRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomTypeRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> AddOrEditRoomType(RoomTypeModel model)
        {
            if (model.RoomTypeID == 0)
            {
                var roomType = new RoomType()
                {
                    RoomTypeID = model.RoomTypeID,
                    Name = model.Name,
                    BasePrice = model.BasePrice,
                    MaxPersonAccept = model.MaxPersonAccept,
                    FeatureID = model.FeatureID,
                    Description = model.Description
                };
                await _context.RoomType.AddAsync(roomType);
            }
            else
            {
                var roomType = _context.RoomType.Find(model.RoomTypeID);
                roomType.Name = model.Name;
                roomType.BasePrice = model.BasePrice;
                roomType.MaxPersonAccept = model.MaxPersonAccept;
                roomType.FeatureID = model.FeatureID;
                roomType.Description = model.Description;
                _context.Update(roomType);
            }
            await _context.SaveChangesAsync();
            return model.FeatureID;
        }

        public async Task<RoomTypeModel> GetRoomTypeById(int id)
        {
            return await _context.RoomType.Where(x => x.RoomTypeID == id)
                .Select(roomType => new RoomTypeModel()
                {
                    RoomTypeID = roomType.RoomTypeID,
                    Name = roomType.Name,
                    BasePrice = roomType.BasePrice,
                    MaxPersonAccept = roomType.MaxPersonAccept,
                    FeatureID = roomType.FeatureID,
                    Feature = roomType.Feature.FeatureName,
                    Description = roomType.Description
                }).FirstOrDefaultAsync();
        }

        public async Task<List<RoomTypeModel>> GetAllRoomTypes()
        {
            var roomTypes = new List<RoomTypeModel>();

            var allRoomTypes = await (from x in _context.RoomType
                                  join y in _context.Feature
                                  on x.FeatureID equals y.FeatureID
                                  select new
                                  {
                                      x.RoomTypeID,
                                      x.Name,
                                      x.BasePrice,
                                      x.MaxPersonAccept,
                                      y.FeatureName,
                                      x.Description
                                  }).ToListAsync();
            if (allRoomTypes?.Any() == true)
            {
                foreach (var roomType in allRoomTypes)
                {
                    roomTypes.Add(new RoomTypeModel()
                    {
                        RoomTypeID = roomType.RoomTypeID,
                        Name = roomType.Name,
                        BasePrice = roomType.BasePrice,
                        MaxPersonAccept = roomType.MaxPersonAccept,
                        Feature = roomType.FeatureName,
                        Description = roomType.Description
                    });
                }
            }


            //var allRoomTypes = await _context.RoomType.ToListAsync();
            //if (allRoomTypes?.Any() == true)
            //{
            //    foreach (var roomType in allRoomTypes)
            //    {
            //        roomTypes.Add(new RoomTypeModel()
            //        {
            //            RoomTypeID = roomType.RoomTypeID,
            //            Name = roomType.Name,
            //            BasePrice = roomType.BasePrice,
            //            MaxPersonAccept = roomType.MaxPersonAccept,
            //            FeatureID = roomType.FeatureID,
            //            Feature = roomType.Feature.FeatureName,
            //            Description = roomType.Description
            //        });
            //    }
            //}
            return roomTypes;
        }
    }
}
