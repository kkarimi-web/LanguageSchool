using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using CleanArch.Application.Utility;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace CleanArch.Application.Services
{
    public class CourseService : ICourseService
    {
        // private ICourseRepository _courseRepository;  
        private IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)//ICourseRepository courseRepository
        {
            // _courseRepository = courseRepository; 
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Course> GetCourses()
        {
            //return new CourseViewModel
            //{
            //    Courses = _courseRepository.GetCourses()
            //};
            return _unitOfWork.courseRepository.GetAll();
        }

        public void Add(Course t)
        {
            t.FromDate = DateManager.SH2M(t.FromDateShamsi);
            t.ToDate = DateManager.SH2M(t.ToDateShamsi);
            // _courseRepository.Add(t);
            _unitOfWork.courseRepository.Add(t);
            _unitOfWork.Commit(); 
        }

        public Course GetCourseById(int id)
        {
            return _unitOfWork.courseRepository.GetById(id);
        }

        public void Update(Course T)
        {
            if (!string.IsNullOrEmpty(T.FromDateShamsi))
                T.FromDate = DateManager.SH2M(T.FromDateShamsi);
            if (!string.IsNullOrEmpty(T.ToDateShamsi))
                T.ToDate = DateManager.SH2M(T.ToDateShamsi);
            _unitOfWork.courseRepository.Update(T);
            _unitOfWork.Commit();
        }

        public void Delete(int Id)
        {
            _unitOfWork.courseRepository.Delete(Id);
            _unitOfWork.Commit();
        }

      
    }
}
