using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace CleanArch.Domain.Models
{
    public class Course
    {
        public int Id { get; set; }       
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int? CourseTypeId { get; set; }
        public virtual CourseType CourseType { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? CourseLevel { get; set; }       
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
