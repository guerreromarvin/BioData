using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioData.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioData.Pages.Bio
{
    public class _PersonalDetailsModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }


        public void OnGet()
        {
        }
    }
}
