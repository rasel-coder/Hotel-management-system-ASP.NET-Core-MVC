using HotelApp.Database;
using HotelApp.Repository;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly BookingRepository _bookingRepository;

        public BookingController(HotelAppContext context,
            BookingRepository bookingRepository)
        {
            _context = context;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _bookingRepository.GetAllBookings();
            return View(data);
        }

        public async Task<IActionResult> SaveBooking(BookingModel model, int id = 0)
        {
            BookingModel booking = new BookingModel();
            if (id != 0)
            {
                booking = await _bookingRepository.GetBookingById(id);
            }
            ViewBag.customer = new SelectList(_context.Customer.ToList(), "CustomerId", "Name");
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveBooking(int id, BookingModel model)
        {
            if (ModelState.IsValid)
            {
                await _bookingRepository.SaveBooking(model);
                ViewBag.customer = new SelectList(_context.Customer.ToList(), "CustomerId", "Name");
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_BookingPartial", _context.Booking.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "SaveBooking", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Booking.FindAsync(id);
            _context.Booking.Remove(booking);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_BookingPartial", _context.Booking.ToList()) });
        }
    }
}
