using HotelApp.Database;
using HotelApp.Repository;
using HotelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly CustomerRepository _customerRepository;

        public CustomerController(HotelAppContext context,
            CustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _customerRepository.GetAllCustomers();
            return View(data);
        }

        public async Task<IActionResult> SaveCustomer(CustomerModel model, int id = 0)
        {
            CustomerModel customer = new CustomerModel();
            if (id != 0)
            {
                customer = await _customerRepository.GetCustomerById(id);
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveCustomer(int id, CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerRepository.SaveCustomer(model);
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_CustomerPartial", _context.Customer.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "SaveCustomer", model) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_CustomerPartial", _context.Customer.ToList()) });
        }
    }
}
