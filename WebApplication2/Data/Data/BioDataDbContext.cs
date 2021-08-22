using BioData.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace BioData.Data
{
    public class BioDataDbContext : DbContext
    {

        public BioDataDbContext(DbContextOptions<BioDataDbContext> options) : base(options)
        { }

        public virtual DbSet<PersonModel> Persons { get; set; }


    }
}
