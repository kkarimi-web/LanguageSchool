using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses();
        void Add(Course T);
        Course GetCourseById(int id);
        void Update(Course T);
        void Delete(int Id);
   
    }
}
