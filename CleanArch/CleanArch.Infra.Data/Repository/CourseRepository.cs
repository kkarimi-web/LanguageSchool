using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Add(Course t)
        {
            _ctx.Courses.Add(t);
            _ctx.SaveChanges();

        }

        public Course GetCourseById(int id)
        {
            return _ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Update(Course T)
        {
            _ctx.Courses.Update(T);
            _ctx.SaveChanges();
        }

        public void Delete(int Id)
        {
            Course T = GetCourseById(Id);
            _ctx.Courses.Remove(T);
            _ctx.SaveChanges();
        }

    }
}
