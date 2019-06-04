using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using VideoShop.Models;

namespace VideoShop.DataAccess
{
    public class PatientContext : DbContext
    {
        public PatientContext() : base("PatientContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}