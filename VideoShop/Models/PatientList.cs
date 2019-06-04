using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Models
{
    public class PatientList
    {
        public string Searchname { get; set; }
        public List<Patient> Patients { get; set; }

        public PatientList()
        {
            Patients = new List<Patient>();
        }
    }
}