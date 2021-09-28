using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vivero.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Vivero.Pages.PlantList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Plant Plant { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Plant = new Plant();
            if (id == null)
            {
                //create
                return Page();
            }

            //update
            Plant = await _db.Plant.FirstOrDefaultAsync(u => u.Id == id);
            if (Plant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                if (Plant.Id == 0)
                {
                    _db.Plant.Add(Plant);
                }
                else
                {
                    _db.Plant.Update(Plant);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }

    }
}