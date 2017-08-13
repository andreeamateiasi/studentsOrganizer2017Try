using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentOrganiser.Models
{
    public class StudentAcademyAdd
    {
        public int AcademyId { get; set; }
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Task { get; set; }
        public string Remarks { get; set; }
        public DateTime Finish { get; set; }
        public DateTime Start { get; set; }
    }
}