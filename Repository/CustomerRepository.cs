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
    public class CustomerRepository
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerRepository(HotelAppContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<int> SaveCustomer(CustomerModel model)
        {
            if (model.CustomerId == 0)
            {
                var customer = new Customer()
                {
                    //CustomerId = model.CustomerId,
                    Name = model.Name,
                    Mobile = model.Mobile,
                    Email = model.Email
                };
                await _context.AddAsync(customer);
            }
            else
            {
                var customer = _context.Customer.Find(model.CustomerId);
                //customer.CustomerId = model.CustomerId;
                customer.Name = model.Name;
                customer.Mobile = model.Mobile;
                customer.Email = model.Email;
                _context.Update(customer);
            }
            await _context.SaveChangesAsync();
            return model.CustomerId;
        }

        public async Task<CustomerModel> GetCustomerById(int id)
        {
            return await _context.Customer.Where(x => x.CustomerId == id)
                .Select(customer => new CustomerModel()
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Mobile = customer.Mobile,
                    Email = customer.Email
                }).FirstOrDefaultAsync();
        }

        public async Task<List<CustomerModel>> GetAllCustomers()
        {
            var customers = new List<CustomerModel>();
            var allCustomers = await _context.Customer.ToListAsync();
            if (allCustomers?.Any() == true)
            {
                foreach (var customer in allCustomers)
                {
                    customers.Add(new CustomerModel()
                    {
                        CustomerId = customer.CustomerId,
                        Name = customer.Name,
                        Mobile = customer.Mobile,
                        Email = customer.Email
                    });
                }
            }
            return customers;
        }
    }
}
