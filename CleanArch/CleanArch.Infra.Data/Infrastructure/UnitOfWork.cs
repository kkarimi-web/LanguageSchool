using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LanguageSchoolDbContext _context;
        public ICourseRepository courseRepository { get; private set; }

        public ICourseDocumentRepository courseDocumentRepository { get; private set; }

        public IFileRepository fileRepository { get; private set; }

        public IPersonRepository personRepository { get; private set; }

        public UnitOfWork(LanguageSchoolDbContext context)
        {
            _context = context;
            courseRepository = new CourseRepository(_context);
            courseDocumentRepository = new CourseDocumentRepository(_context);
            fileRepository = new FileRepository(_context);
            personRepository = new PersonRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync();
        }

        #region Dispose

        private bool disposed = false;



        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
