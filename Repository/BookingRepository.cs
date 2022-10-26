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
    public class BookingRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookingRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> SaveBooking(BookingModel model)
        {
            if (model.BookingId == 0)
            {
                var booking = new Booking()
                {
                    RoomNum = model.RoomNum,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    CustomerId = model.CustomerId,
                    DailyPrice = model.DailyPrice,
                    TotalPrice = model.TotalPrice,
                    IsPaid = model.IsPaid
                };
                await _context.AddAsync(booking);
            }
            else
            {
                var booking = _context.Booking.Find(model.BookingId);
                booking.RoomNum = model.RoomNum;
                booking.FromDate = model.FromDate;
                booking.ToDate = model.ToDate;
                booking.CustomerId = model.CustomerId;
                booking.DailyPrice = model.DailyPrice;
                booking.TotalPrice = model.TotalPrice;
                booking.IsPaid = model.IsPaid;
                _context.Update(booking);
            }
            await _context.SaveChangesAsync();
            return model.BookingId;
        }

        public async Task<BookingModel> GetBookingById(int id)
        {
            return await _context.Booking.Where(x => x.BookingId == id)
                .Select(model => new BookingModel()
                {
                    BookingId = model.BookingId,
                    RoomNum = model.RoomNum,
                    FromDate = model.FromDate,
                    ToDate = model.ToDate,
                    CustomerId  = model.CustomerId,
                    DailyPrice = model.DailyPrice,
                    TotalPrice = model.TotalPrice,
                    IsPaid = model.IsPaid
                }).FirstOrDefaultAsync();
        }

        public async Task<List<BookingModel>> GetAllBookings()
        {
            var bookings = new List<BookingModel>();

            var allBookings = await (from x in _context.Booking
                                      join y in _context.Customer
                                      on x.CustomerId equals y.CustomerId
                                      select new
                                      {
                                          x.BookingId,
                                          x.RoomNum,
                                          x.FromDate,
                                          x.ToDate,
                                          y.Name,
                                          x.DailyPrice,
                                          x.TotalPrice,
                                          x.IsPaid
                                      }).ToListAsync();
            if (allBookings?.Any() == true)
            {
                foreach (var model in allBookings)
                {
                    bookings.Add(new BookingModel()
                    {
                        BookingId = model.BookingId,
                        RoomNum = model.RoomNum,
                        FromDate = model.FromDate,
                        ToDate = model.ToDate,
                        Customer = model.Name,
                        DailyPrice = model.DailyPrice,
                        TotalPrice = model.TotalPrice,
                        IsPaid = model.IsPaid
                    });
                }
            }
            return bookings;
        }
    }
}
