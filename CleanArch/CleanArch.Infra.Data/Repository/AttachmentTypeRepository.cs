using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using CleanArch.Infra.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
   public class AttachmentTypeRepository:Repository<AttachmentType>,IAttachmentTypeRepository
    {
        public AttachmentTypeRepository(LanguageSchoolDbContext _context):base(_context)
        {

        }
    }
}
