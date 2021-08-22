using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data.Models
{
    public class Person
    {
        public Guid Id{ get; set; }
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Title { get; set; }   
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateDeleted { get; set; }
        public string Overview { get; set; }
        public List<Education> Educations { get; set; }
        public List<Work> Works { get; set; }


    }

    public class Education
    {
        public string Institution { get; set; }
        public int MonthCompleted {get;set; }
        public int YearCompleted { get; set; }
        public string Level { get; set; }
        public string Course { get; set; }
        public string Description { get; set; }

    }

    public class Work
    {
        public Guid Id { get; set; }
        public string Organisation {get;set; }
        public bool IsSelfEmployed {get;set; }
        public DateTime DateFrom {get; set; }
        public DateTime DateTo { get; set; }

    }
}
