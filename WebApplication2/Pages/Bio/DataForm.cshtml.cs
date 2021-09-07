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
using Microsoft.AspNetCore.Http;
using System.Xml;
using Newtonsoft.Json;
using System.Data;
using System.ComponentModel;
using Nelibur.ObjectMapper;
using System.Net;

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

        public IActionResult OnGetSomeString()
        {
            return Content("something");
        }


        public IActionResult OnPostButton2(IFormCollection data)
        {
            var u = DateTime.Now;
            var formdata = Request.Form["PageJSON"];

            var deserializedPerson = JsonConvert.DeserializeObject<ProfileRootobject>(formdata);


            DataTable dtperson = GenerateDataTableFromClass<Person>("person");
            DataTable dtcontacts = GenerateDataTableFromClass<Contacts>("contacts");
            DataTable dteducation = GenerateDataTableFromClass<Education>("education");
            DataTable dtwork = GenerateDataTableFromClass<Workhistory>("workhistory");
            DataTable dtchiled = GenerateDataTableFromClass<Child>("child");
            DataTable dtproject = GenerateDataTableFromClass<Project>("project");


            var g = dtperson.NewRow();
            g["FirstName"] = deserializedPerson.person.FirstName;
            g["LastName"] = deserializedPerson.person.LastName;
            g["MiddleName"] = deserializedPerson.person.MiddleName;

            dtperson.Rows.Add(g);   

            var ds = new DataSet();
            ds.Tables.Add(dtperson);
            ds.Tables.Add(dtcontacts);
            ds.Tables.Add(dteducation);
            ds.Tables.Add(dtwork);
            ds.Tables.Add(dtproject);
            ds.Tables.Add(dtchiled);
            ds.WriteXmlSchema("PD.XSD");

            return Content("file saved");
        }

        //private byte[] GetPhoto()
        //{
        //    try
        //    {
        //        var _fb = new FacebookClient(Session["FbuserToken"].ToString());
        //        dynamic resultMe = _fb.Get(GetProfileId() + "?fields=picture.width(480).height(480)");

        //        WebClient webClient = new WebClient();
        //        string urlPicture = resultMe.picture.data.url;

        //        return webClient.DownloadData(urlPicture);

        //    }

        //    catch (Exception)
        //    {

        //        return null;
        //    }

        //}


        private static DataTable GenerateDataTableFromClass<T>(string tablename)
        {
            PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable(tablename);
            foreach (PropertyDescriptor p in props)
                dt.Columns.Add(p.Name, p.PropertyType);
            return dt;
        }

        public IActionResult OnPostButton1(IFormCollection data)
        {
            var u = DateTime.Now;
            var formdata = Request.Form["PageJSON"];

            XmlDocument doc = JsonConvert.DeserializeXmlNode(@"{'data':" + formdata + "}");
            return Content(doc.InnerXml);
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
