using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext() : base("DBCS")
        {
            
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        
    }
}