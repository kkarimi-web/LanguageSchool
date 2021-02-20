using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface ICourseDocumentService
    {
        void Add(CourseDocument T,int courseId);
        CourseDocument GetByCourseId(int id);
    }
}
