using HotelApp.Database;
using HotelApp.Repository;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly HotelRepository _hotelRepository;

        public HotelController(HotelAppContext context,
            HotelRepository hotelRepository)
        {
            _context = context;
            _hotelRepository = hotelRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _hotelRepository.GetAllHotels();
            return View(data);
        }

        public async Task<IActionResult> SaveHotel(HotelModel model, int id = 0)
        {
            HotelModel hotel = new HotelModel();
            if (id != 0)
            {
                hotel = await _hotelRepository.GetHotelById(id);
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveHotel(int id, HotelModel model)
        {
            if (ModelState.IsValid)
            {
                await _hotelRepository.SaveHotel(model);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_HotelPartial", _context.Hotel.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "SaveHotel", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_HotelPartial", _context.Hotel.ToList()) });
        }
    }
}
