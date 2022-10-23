using HotelApp.Database;
using HotelApp.Repository;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class RoomController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly RoomRepository _roomRepository;

        public RoomController(HotelAppContext context,
            RoomRepository roomRepository)
        {
            _context = context;
            _roomRepository = roomRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _roomRepository.GetAllRooms();
            return View(data);
        }

        public async Task<IActionResult> AddOrEdit(RoomModel model, int id = 0)
        {
            RoomModel room = new RoomModel();
            if (id != 0)
            {
                room = await _roomRepository.GetRoomById(id);
            }
            ViewBag.roomType = new SelectList(await _context.RoomType.ToListAsync(), "RoomTypeID", "Name");
            return View(room);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, RoomModel model)
        {
            if (ModelState.IsValid)
            {
                await _roomRepository.AddOrEditRoom(model);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_RoomPartial", _context.Room.ToList()) });
            }
            ViewBag.roomType = new SelectList(await _context.RoomType.ToListAsync(), "RoomTypeID", "Name");
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomType = await _context.Room.FindAsync(id);
            _context.Room.Remove(roomType);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_RoomPartial", _context.Room.ToList()) });
        }
    }
}
