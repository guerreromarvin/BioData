﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BioData.Data;
using BioData.Data.Models;

namespace BioData.Pages.EFCO
{
    public class EditModel : PageModel
    {
        private readonly BioData.Data.BioDataDbContext _context;

        public EditModel(BioData.Data.BioDataDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PersonModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonModelExists(PersonModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonModelExists(Guid id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
