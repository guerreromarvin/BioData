using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioData.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BioData.Pages.Bio
{
    public class DataFormModel : PageModel
    {
        [BindProperty]
        public Person person { get; set; }


        public string PageJSON {get;set;}

        public void OnGet()
        {
        }

        public void OnPost()
        {
            var u = DateTime.Now;
        }
    }
}
