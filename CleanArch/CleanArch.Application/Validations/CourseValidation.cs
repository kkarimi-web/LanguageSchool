using System;
using System.Collections.Generic;
using System.Text;
using CleanArch.Domain.Models;
using FluentValidation;


namespace CleanArch.Application.Validations
{
    public class CourseValidation : AbstractValidator<Course>
    {
        public CourseValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Course Name is Required");
            RuleFor(f => f.ImageUrl).NotEmpty().When(c => c.Name.Contains("Summit")).WithMessage("Image Url is Required");
        }
    }
}
