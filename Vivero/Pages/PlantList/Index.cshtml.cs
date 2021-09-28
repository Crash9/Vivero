using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vivero.Model;

namespace Vivero.Pages.PlantList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Plant> Plants { get; set; }

        public async Task OnGet()
        {
            Plants = await _db.Plant.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id) 
        {
            var plant = await _db.Plant.FindAsync(id);
            if (plant == null) 
            {
                return NotFound();
            }
            else 
            {
                _db.Plant.Remove(plant);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
        } 
    }
}
