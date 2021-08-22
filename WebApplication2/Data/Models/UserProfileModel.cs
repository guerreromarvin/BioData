using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data.Models
{
    public class UserProfileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DetailsJson { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public string UserId {get;set; }

    }
}
