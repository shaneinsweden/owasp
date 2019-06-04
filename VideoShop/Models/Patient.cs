using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoShop.Models
{ 
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string Illness  { get; set; }
        public bool IsTerminal { get; set; }
        public bool IsSensitive { get; set; }
    }
}