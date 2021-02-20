using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseTypeRepository : ICourseTypeRepository
    {
        public LanguageSchoolDbContext _ctx;

        public CourseTypeRepository(LanguageSchoolDbContext context)
        {
            _ctx = context;
        }       

        public async Task<IEnumerable<CourseType>> GetCourseTypesAsync()
        {
            return await _ctx.CourseType.ToListAsync();
        }

        public async Task<IEnumerable<CourseType>> GetCourseTypesAsync(int id)
        {
            return await _ctx.CourseType.Where(c => c.Id == id).ToListAsync();
        }
    }
}
