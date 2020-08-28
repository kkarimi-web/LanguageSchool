using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private ICourseTypeRepository CourseTypeRepository;

        public IEnumerable<CourseType> GetCourseTypes()
        {
           return CourseTypeRepository.GetCourseTypes();
        }
    }
}
