using HotelApp.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApp.Controllers
{
    public class FeatureController : Controller
    {
        private readonly HotelAppContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FeatureController(HotelAppContext context, 
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Feature.ToListAsync());
        }

        public async Task<IActionResult> AddOrEdit(Feature model, int id = 0)
        {
            Feature feature = new Feature();
            if (id != 0)
            {
                feature = _context.Feature.Where(x => x.FeatureID == id).FirstOrDefault<Feature>();
            }
            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, Feature feature)
        {
            if (ModelState.IsValid)
            {
                if (feature.IconUpload != null)
                {
                    string folder = "image/feature/";
                    folder += Guid.NewGuid().ToString() + feature.IconUpload.FileName;
                    string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    feature.Icon = "/" + folder;
                    await feature.IconUpload.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                }

                if (id == 0)
                {
                    _context.Add(feature);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    _context.Update(feature);
                    await _context.SaveChangesAsync();
                }

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_FeaturePartial", _context.Feature.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", feature) });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Feature.FindAsync(id);
            _context.Feature.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_FeaturePartial", _context.Feature.ToList()) });
        }
    }
}
