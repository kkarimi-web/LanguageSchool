using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseTypeService
    {
        Task<IEnumerable<CourseType>> GetCourseTypesAsync();
        Task<IEnumerable<CourseType>> GetCourseTypesAsync(int id);
    }
}
