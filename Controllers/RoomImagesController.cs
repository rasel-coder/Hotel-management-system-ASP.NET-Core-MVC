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
    public class RoomImagesController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly RoomImagesRepository _roomImagesRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RoomImagesController(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await _roomImagesRepository.GetAllRoomImages();
            return View();
        }

        public async Task<IActionResult> AddOrEdit(RoomImagesModel model, int id = 0)
        {
            RoomImagesModel roomImagesModel = new RoomImagesModel();
            if (id != 0)
            {
                roomImagesModel = await _roomImagesRepository.GetRoomImagesById(id);
            }
            ViewBag.roomImages = new SelectList(await _context.Feature.ToListAsync(), "ImageID", "RoomNumber");
            return View(roomImagesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, RoomImagesModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.RoomImageUpload != null)
                {
                    string folder = "image/roomImage/";
                    folder += Guid.NewGuid().ToString() + model.RoomImageUpload.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    model.RoomImage = "/" + folder;
                    await model.RoomImageUpload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                await _roomImagesRepository.AddOrEditRoomImages(model);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_RoomImagesPartial", _context.Feature.ToList()) });
            }
            ViewBag.roomImages = new SelectList(await _context.Feature.ToListAsync(), "ImageID", "RoomNumber");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomImages = await _context.RoomImages.FindAsync(id);
            _context.RoomImages.Remove(roomImages);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_RoomImagesPartial", _context.RoomImages.ToList()) });
        }
    }
}
