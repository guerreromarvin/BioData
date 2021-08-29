using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel;
using System.Threading.Tasks;
using AspNetCore.Reporting;
//using AspNetCore.Reporting;
//using AspNetCore.Reporting.ReportExecutionService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
//using static Humanizer.In;

namespace BioData.Pages.Render
{
    public class ViewFormModel : PageModel
    {
        private readonly IWebHostEnvironment _env;
        //public void OnGet()
        //{
        //}

        public ViewFormModel(IWebHostEnvironment env)
        {
            _env = env;
        }



        public IActionResult OnGet()
        {
            var dt = new DataTable();
            dt = GetEmployeeList();
            string mimetype = "";
            int extension = 1;
            var path = $"{this._env.WebRootPath}\\Reports\\Employees.rdlc";
            //    var path = $@"C:\Reports\EMP.RDL";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("prm", "RDLC report (Set as parameter)");

            LocalReport lr = new LocalReport(@"D:\Projects\BioData\BioData\WebApplication2\wwwroot\Reports\Employees.rdlc");
            lr.AddDataSource("dsEmployee", dt);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");
        }

        private DataTable GetEmployeeList()
        {
            var dt = new DataTable();
            dt.Columns.Add("EmpId");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("Department");
            dt.Columns.Add("BirthDate");
            DataRow row;

            for (int i = 1; i < 100; i++)
            {
                row = dt.NewRow();
                row["EmpId"] = i;
                row["EmpName"] = i.ToString() + " Empl";
                row["Department"] = "XXYY";
                row["BirthDate"] = DateTime.Now.AddDays(-10000);
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
