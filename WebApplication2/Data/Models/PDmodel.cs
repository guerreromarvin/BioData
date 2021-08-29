using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data.Models
{

    public class ProfileRootobject
    {
        public Person person { get; set; }
        public Education[] education { get; set; }
        public Workhistory[] workhistory { get; set; }
        public Child[] children { get; set; }
        public Project[] projects { get; set; }
        public Contacts contacts { get; set; }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        public string BirthPlace { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public string Spouse { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Religion { get; set; }
        public string Citizenship { get; set; }
        public string CivilStatus { get; set; }
        public string Background { get; set; }
        public string RolesAndResponsibilities { get; set; }
    }

    public class Contacts
    {
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    public class Education
    {
        public string Institution { get; set; }
    }

    public class Workhistory
    {
        public string School { get; set; }
        public string Organisation { get; set; }
        public string Location { get; set; }
        public string MonthCompletedFrom { get; set; }
        public string YearCompletedFrom { get; set; }
        public string MonthCompletedTo { get; set; }
        public string YearCompletedTo { get; set; }
        public string RolesAndRespinsibilities { get; set; }
        public string Position { get; set; }
        public string Decription { get; set; }
        public string RolesAndResponsibilities { get; set; }
    }

    public class Child
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
    }

    public class Project
    {
        public string Description { get; set; }
        public string ProjectName { get; set; }
        public string Organisation { get; set; }
    }

}