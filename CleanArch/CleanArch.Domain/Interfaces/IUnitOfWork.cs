using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository courseRepository { get; }
        ICourseDocumentRepository courseDocumentRepository { get; }
        IFileRepository fileRepository { get; }
        IPersonRepository personRepository { get; }
        IAttachmentTypeRepository attachmentTypeRepository{get;}
        void Commit();
        Task<int> CommitAsync();
    }
}
