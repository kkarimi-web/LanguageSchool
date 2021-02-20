using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseTypeRepository
    {
        Task<IEnumerable<CourseType>> GetCourseTypesAsync();
        Task<IEnumerable<CourseType>> GetCourseTypesAsync(int id);
    }
}
