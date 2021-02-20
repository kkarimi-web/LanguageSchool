using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

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
        public string FromDateShamsi { get; set; }
        public DateTime? ToDate { get; set; }
        public string ToDateShamsi { get; set; }
        public int? CourseLevel { get; set; }       
        public string Description { get; set; }
        //public string ImageName { get; set; }
        //public string ImageId { get; set; }
        //public ICollection<IFormFile> UploadFiles { get; set; }
        //public string SecondImageName { get; set; }
        //public string SecondImageId { get; set; }
       
    }
}
