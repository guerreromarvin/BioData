using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Areas.Api
{
    public class ProfileDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
