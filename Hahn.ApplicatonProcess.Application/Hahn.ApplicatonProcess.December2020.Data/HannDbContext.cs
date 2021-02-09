using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hahn.ApplicatonProcess.December2020.Data
{
    public class HannDbContext : DbContext
    {
        public HannDbContext(DbContextOptions options) : base(options)
        { }

        public virtual DbSet<Applicant> Applicants { get; set; }
    }
}
