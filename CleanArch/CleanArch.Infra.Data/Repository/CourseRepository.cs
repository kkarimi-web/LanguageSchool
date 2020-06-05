using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        public LanguageSchoolDbContext _ctx;

        public CourseRepository(LanguageSchoolDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<Course> GetCourses()
        {
            return _ctx.Courses;
        }
    }
}
