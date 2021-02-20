using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class CourseTypeService : ICourseTypeService
    {
        private ICourseTypeRepository _courseTypeRepository;

        public CourseTypeService(ICourseTypeRepository courseTypeRepository)
        {
            _courseTypeRepository = courseTypeRepository;
        }

        //public IEnumerable<CourseType> GetCourseTypes()
        //{
        //   return _courseTypeRepository.GetCourseTypes();
        //}

        public async Task<IEnumerable<CourseType>> GetCourseTypesAsync()
        {
            return await _courseTypeRepository.GetCourseTypesAsync();
        }

        public async Task<IEnumerable<CourseType>> GetCourseTypesAsync(int id)
        {
            return await _courseTypeRepository.GetCourseTypesAsync(id);
        }
    }
}
