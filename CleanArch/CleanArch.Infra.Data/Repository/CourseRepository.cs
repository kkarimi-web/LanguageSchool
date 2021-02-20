using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseRepository :Repository<Course>, ICourseRepository
    {
        //    private readonly LanguageSchoolDbContext _ctx;

        public CourseRepository(LanguageSchoolDbContext ctx) : base(ctx)
        {
            
        }

        //    public IEnumerable<Course> GetCourses()
        //    {
        //        return _ctx.Courses;
        //    }

        //    public void Add(Course t)
        //    {
        //        _ctx.Courses.Add(t);
        //        _ctx.SaveChanges();

        //    }

        //    public Course GetCourseById(int id)
        //    {
        //        return _ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
        //    }

        //    public void Update(Course T)
        //    {
        //        _ctx.Courses.Update(T);
        //        _ctx.SaveChanges();
        //    }

        //    public void Delete(int Id)
        //    {
        //        Course T = GetCourseById(Id);
        //        _ctx.Courses.Remove(T);
        //        _ctx.SaveChanges();
        //    }

        //    public void AddWithAttachment(Course T, string ColName, string pathlocator)//, string doc_Id,string doc_name)
        //    {
        //        // T.ImageId = doc_Id;
        //        // T.ImageName = doc_name;
        //        _ctx.Courses.Add(T);
        //        _ctx.SaveChanges();
        //    }

        //    public void UpdateWithAttachment(Course T, string doc_Id, string doc_name)
        //    {
        //        // T.ImageId = doc_Id;
        //        // T.ImageName = doc_name;
        //        _ctx.Courses.Update(T);
        //        _ctx.SaveChanges();
        //    }
    }
}
