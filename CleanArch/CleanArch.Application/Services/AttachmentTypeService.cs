using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CleanArch.Application.Services
{
    public class AttachmentTypeService : IAttachmentTypeService
    {
        private IUnitOfWork _unitOfWork;
        public AttachmentTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(AttachmentType t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(AttachmentType T)
        {
            throw new NotImplementedException();
        }
    }
}
