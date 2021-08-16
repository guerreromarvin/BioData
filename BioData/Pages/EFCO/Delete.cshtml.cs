using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BioData.Data;
using BioData.Data.Models;

namespace BioData.Pages.EFCO
{
    public class DeleteModel : PageModel
    {
        private readonly BioData.Data.BioDataDbContext _context;

        public DeleteModel(BioData.Data.BioDataDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonModel = await _context.Persons.FirstOrDefaultAsync(m => m.Id == id);

            if (PersonModel == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonModel = await _context.Persons.FindAsync(id);

            if (PersonModel != null)
            {
                _context.Persons.Remove(PersonModel);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
