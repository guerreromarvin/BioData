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
    public class IndexModel : PageModel
    {
        private readonly BioData.Data.BioDataDbContext _context;

        public IndexModel(BioData.Data.BioDataDbContext context)
        {
            _context = context;
        }

        public IList<PersonModel> PersonModel { get;set; }

        public async Task OnGetAsync()
        {
            PersonModel = await _context.Persons.ToListAsync();
        }
    }
}
