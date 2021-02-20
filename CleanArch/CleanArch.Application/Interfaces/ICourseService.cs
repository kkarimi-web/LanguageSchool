using CleanArch.Application.ViewModels;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
  public interface ICourseService
    {
       CourseViewModel GetCourses();
        void Add(Course t);
        Course GetCourseById(int id);
        void Update(Course T);
        void Delete(int Id);
       
    }
}
