using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentOrganiser.Models
{
    public class Academy
    {
        public Academy()
        {
            this.Students = new HashSet<Student>();
        }
        public int AcademyId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Task { get; set; }
        public string Remarks { get; set; }
        public DateTime Finish { get; set; }
        public DateTime Start { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}