using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }

        public string TeacherFirstName { get; set; }

        public string TeacherLastName { get; set; }

        public List<Student> ListOfStudent { get; set; }

    }
}