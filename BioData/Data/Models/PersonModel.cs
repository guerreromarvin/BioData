using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data.Models
{
    [Table("Person")]
    public class PersonModel
    {
      public Guid Id { get; set; }
      public string FullName { get; set; }
      public string Address { get; set; }
      public string ContactInfo { get; set; }
      public string SocialInfo { get; set; }
      public string WorkHistory { get; set; }
      public string Education { get; set; }
    }

    }
