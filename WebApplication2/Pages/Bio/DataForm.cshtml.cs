using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BioData.Data;
using BioData.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BioData.Pages.Bio
{
    public class DataFormModel : PageModel
    {
        [BindProperty]
        public string PageJSON { get; set; } = "{}";

        [BindProperty]
        public string PersonId { get; set; }


        private ApplicationDbContext dbc { get; set; }
        [BindProperty]
        public string UserId { get; set; }


        public DataFormModel(ApplicationDbContext _dbc)
        {
            this.dbc = _dbc;
        }

        public void OnGet()
        {
            if (User != null)
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var g = dbc.UserProfile.SingleOrDefault(c => c.UserId == UserId);
            if (g != null && !string.IsNullOrWhiteSpace(g.DetailsJson))
            {
                PageJSON = g.DetailsJson;
            }
            else
            {
                PageJSON = "{}";
            }
        }

        public void OnPost()
        {
            var u = DateTime.Now;
            var formdata = Request.Form["PageJSON"];
            if (User != null)
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var g = dbc.UserProfile.SingleOrDefault(c => c.UserId == UserId);
            if (g == null)
            {
                var p = new UserProfileModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId,
                    Name = User.Identity.Name,
                    DetailsJson = formdata,
                    Created = DateTime.Now
                };
                dbc.UserProfile.Add(p);
            }
            else
            {
                var hp = new HistoryUserProfileModel()
                {
                    Id = Guid.NewGuid(),
                    UserId = UserId,
                    Name = User.Identity.Name,
                    DetailsJson = formdata,
                    Created = DateTime.Now,
                    ParentId = g.Id
                };
                dbc.HistoryUserProfile.Add(hp);
                g.DetailsJson = formdata;
            }
            dbc.SaveChanges();
        }
    }
}
