using CleanArch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
   public interface IAttachmentTypeService
    {
        void Add(AttachmentType t);     
        void Update(AttachmentType T);
        void Delete(int Id);
    }
}
