using HotelApp.Database;
using HotelApp.Repository;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class RoomTypeController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly RoomTypeRepository _roomTypeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomTypeController(HotelAppContext context,
            RoomTypeRepository roomTypeRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _roomTypeRepository = roomTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _roomTypeRepository.GetAllRoomTypes();
            return View(data);
        }

        public async Task<IActionResult> AddOrEdit(RoomTypeModel model, int id = 0)
        {
            RoomTypeModel roomType = new RoomTypeModel();
            if (id != 0)
            {
                roomType = await _roomTypeRepository.GetRoomTypeById(id);
            }
            ViewBag.feature = new SelectList(await _context.Feature.ToListAsync(), "FeatureID", "FeatureName");
            return View(roomType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, RoomTypeModel model)
        {
            if (ModelState.IsValid)
            {
                await _roomTypeRepository.AddOrEditRoomType(model);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_RoomTypePartial", _context.RoomType.ToList()) });
            }
            ViewBag.feature = new SelectList(await _context.Feature.ToListAsync(), "FeatureID", "FeatureName");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.RoomType.FindAsync(id);
            _context.RoomType.Remove(roomType);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_RoomTypePartial", _context.RoomType.ToList()) });
        }

        //private async Task<List<RoomType>> GetData()
        //{
        //    var roomTypes = new List<RoomType>();
        //    var allRoomType = await _context.RoomType.ToListAsync();
        //    var allData = await(from x in _context.RoomType
        //                        join y in _context.Feature
        //                        on x.FeatureID equals y.FeatureID
        //                        select new
        //                        {
        //                            x.RoomTypeID,
        //                            x.Name,
        //                            x.BasePrice,
        //                            x.MaxPersonAccept,
        //                            y.FeatureName,
        //                            x.Description
        //                        }).ToListAsync();
        //    if (allData?.Any() == true)
        //    {
        //        foreach (var roomType in allData)
        //        {
        //            roomTypes.Add(new RoomType()
        //            {
        //                RoomTypeID = roomType.RoomTypeID,
        //                Name = roomType.Name,
        //                BasePrice = roomType.BasePrice,
        //                MaxPersonAccept = roomType.MaxPersonAccept,
        //                FeatureName = roomType.FeatureName,
        //                Description = roomType.Description
        //            });
        //        }
        //    }
        //    return roomTypes;
        //}
    }
}
