using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vivero.Model;

namespace Vivero.Pages.PlantList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Plant Plant { get; set; }
        public void OnGet()
        {
        }
        public async Task <IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Plant.AddAsync(Plant);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else 
            {
                return Page();
            }
        }
    }
}