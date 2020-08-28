using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseTypeRepository : ICourseTypeRepository
    {
        public LanguageSchoolDbContext _ctx;

        public CourseTypeRepository(LanguageSchoolDbContext context)
        {
            _ctx = context;
        }

        IEnumerable<CourseType> ICourseTypeRepository.GetCourseTypes()
        {
            return _ctx.CourseTypes;
        }
    }
}
