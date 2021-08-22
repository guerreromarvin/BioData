using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data.Models
{
    public class HistoryUserProfileModel 
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string DetailsJson { get; set; }
        public DateTime Created { get; set; }
        public string UserId {get;set; }
    }
}
