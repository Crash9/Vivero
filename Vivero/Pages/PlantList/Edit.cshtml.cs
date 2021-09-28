using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vivero.Model;

namespace Vivero.Pages.PlantList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Plant Plant { get; set; }
        public async Task OnGet(int id)
        {
            Plant = await _db.Plant.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var PlantFromDb = await _db.Plant.FindAsync(Plant.Id);
                PlantFromDb.Name = Plant.Name;
                PlantFromDb.Price = Plant.Price;
                PlantFromDb.Stock = Plant.Stock;
                PlantFromDb.Photo = Plant.Photo;
                PlantFromDb.Description = Plant.Description;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }

    }
}
