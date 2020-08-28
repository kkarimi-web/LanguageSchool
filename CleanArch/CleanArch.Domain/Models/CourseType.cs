using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Models
{
   public class CourseType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool? IsActive { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
