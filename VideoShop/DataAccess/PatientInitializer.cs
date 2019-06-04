using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoShop.Models;

namespace VideoShop.DataAccess
{
    public class PatientInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PatientContext>
    {
        protected override void Seed(PatientContext context)
        {
            var patients = new List<Patient>
            {
                new Patient
                {
                    PatientId = 1, Illness = "Allergy", IsSensitive = false, IsTerminal = false,
                    PatientName = "shane murnion"
                },
                new Patient
                {
                    PatientId = 1, Illness = "plague", IsSensitive = true, IsTerminal = true, PatientName = "john doe"
                },
                new Patient
                {
                    PatientId = 1, Illness = "morning sickness", IsSensitive = true, IsTerminal = false,
                    PatientName = "lotte ascelin"
                },
                new Patient
                {
                    PatientId = 1, Illness = "ocd", IsSensitive = false, IsTerminal = false, PatientName = "sara nörd"
                },
                new Patient
                {
                    PatientId = 1, Illness = "insomnia", IsSensitive = false, IsTerminal = false,
                    PatientName = "johan Femi"
                },
                new Patient
                {
                    PatientId = 1, Illness = "mad cow disease", IsSensitive = true, IsTerminal = true,
                    PatientName = "jonna heidi"
                },

            };

            patients.ForEach(s => context.Patients.Add(s));
            context.SaveChanges();
        }
    }
}