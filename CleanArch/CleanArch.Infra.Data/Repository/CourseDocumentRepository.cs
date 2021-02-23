using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class CourseDocumentRepository :Repository<CourseDocument>, ICourseDocumentRepository
    {
      //  public LanguageSchoolDbContext _ctx;
      //  private IFileRepository _fileRepository;

        public CourseDocumentRepository(LanguageSchoolDbContext ctx) : base(ctx)//, IFileRepository fileRepository
        {
            //_ctx = ctx;
           // _fileRepository = fileRepository;
        }

        public CourseDocument GetByCourseId(int id)
        {
           return  _context.CourseDocument.Where(c => c.Courseid == id).FirstOrDefault();
        }
        //public void Add(CourseDocument T,int courseid)
        //{
        //    if (T.IntroImage != null)
        //    {
        //        T.IntroImageName = ContentDispositionHeaderValue.Parse(T.IntroImage.ContentDisposition)
        //                          .FileName.ToString().Trim('"');
        //        T.IntroImageId = _fileRepository.SaveFile(T.IntroImage, "Course\\" + courseid);
        //    }

        //    if (T.SecondImage != null)
        //    {
        //        T.SecondImageName = ContentDispositionHeaderValue.Parse(T.SecondImage.ContentDisposition)
        //                                         .FileName.ToString().Trim('"');
        //        T.SecondImageId = _fileRepository.SaveFile(T.SecondImage, "Course\\" + courseid);
        //    }
        //    T.Courseid = courseid;
        //    _ctx.Add(T);
        //    _ctx.SaveChanges();
        //}
    }
}
