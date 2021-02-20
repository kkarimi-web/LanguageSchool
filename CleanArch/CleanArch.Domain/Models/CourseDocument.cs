using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Models
{
    public class CourseDocument
    {
        public int Id { get; set; }
        public int? Courseid { get; set; }
        public IFormFile IntroImage { get; set; }
        public string IntroImageName { get; set; }
        public string IntroImageId { get; set; }
        public IFormFile SecondImage { get; set; }
        public string SecondImageName { get; set; }
        public string SecondImageId { get; set; }
    }
}
