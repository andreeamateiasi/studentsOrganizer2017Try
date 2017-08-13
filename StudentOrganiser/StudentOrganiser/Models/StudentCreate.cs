using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentOrganiser.Models
{
   
    public class StudentCreate
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Faculty { get; set; }
        public DateTime FacultyStart { get; set; }
        public int academy { get; set; }
    }
}