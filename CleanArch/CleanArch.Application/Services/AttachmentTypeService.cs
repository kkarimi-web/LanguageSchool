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
            _unitOfWork.attachmentTypeRepository.Add(t);
        }

        public void Delete(int Id)
        {
            AttachmentType T = _unitOfWork.attachmentTypeRepository.GetById(Id);
            if (T != null)
                _unitOfWork.attachmentTypeRepository.Delete(T);
        }

        public void Update(AttachmentType T)
        {
            _unitOfWork.attachmentTypeRepository.Update(T);
        }
    }
}
