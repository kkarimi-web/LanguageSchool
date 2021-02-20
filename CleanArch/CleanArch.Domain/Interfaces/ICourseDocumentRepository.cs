using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
  public interface ICourseDocumentRepository:IRepository<CourseDocument>
    {
        // void Add(CourseDocument T,int courseid);
        CourseDocument GetByCourseId(int id);
    }
}
