using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Transactions;

namespace CleanArch.Application.Services
{
    public class CourseDocumentServie : ICourseDocumentService
    {
        // private ICourseDocumentRepository _courseDocumentRepository;
        private IUnitOfWork _unitofwork;

        public CourseDocumentServie(IUnitOfWork unitOfWork)//ICourseDocumentRepository courseDocumentRepository)
        {
            // _courseDocumentRepository = courseDocumentRepository;
            _unitofwork = unitOfWork;
        }


        public void Add(CourseDocument T, int courseid)
        {

            // _courseDocumentRepository.Add(T,courseId);
            //
            using (var transactionScope = new TransactionScope())
            {

                if (T.IntroImage != null)
                {
                    T.IntroImageName = ContentDispositionHeaderValue.Parse(T.IntroImage.ContentDisposition)
                                      .FileName.ToString().Trim('"');
                    T.IntroImageId = _unitofwork.fileRepository.SaveFile(T.IntroImage, "Course\\" + courseid);
                }

                if (T.SecondImage != null)
                {
                    T.SecondImageName = ContentDispositionHeaderValue.Parse(T.SecondImage.ContentDisposition)
                                                     .FileName.ToString().Trim('"');
                    T.SecondImageId = _unitofwork.fileRepository.SaveFile(T.SecondImage, "Course\\" + courseid);
                }
                T.Courseid = courseid;
                _unitofwork.courseDocumentRepository.Add(T);
                _unitofwork.Commit();
                //
                transactionScope.Complete();
            }
        }
    }
}
