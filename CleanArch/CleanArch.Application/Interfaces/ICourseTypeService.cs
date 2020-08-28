using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseTypeService
    {
        IEnumerable<CourseType> GetCourseTypes();
    }
}
