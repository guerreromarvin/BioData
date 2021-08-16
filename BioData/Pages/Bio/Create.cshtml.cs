using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioData.Data;
using BioData.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioData.Pages.Bio
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public PersonModel PersonData { get; set; }

        private readonly BioDataDbContext _context;

        public CreateModel(BioDataDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (PersonData.Id == Guid.Empty)
            {
                CreateNewPerson(PersonData);
            }
        }

        private void CreateNewPerson(PersonModel personData)
        {
            personData.Id = Guid.NewGuid();
            _context.Persons.Add(personData);
            _context.SaveChanges();
        }
    }
}
