using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BioData.Data;
using BioData.Data.Models;

namespace BioData.Pages.EFCO
{
    public class CreateModel : PageModel
    {
        private readonly BioData.Data.BioDataDbContext _context;

        public CreateModel(BioData.Data.BioDataDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PersonModel PersonModel { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Persons.Add(PersonModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
