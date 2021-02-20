using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Interfaces
{
    public interface IFileRepository:IRepository<vDocument>
    {
        string SaveFile(IFormFile formFile, string Path);
        void DeleteFile(string pathlocator, string RefrenceTable, string ColumnName);
        vDocument DownloadFile(string pathlocator);
    }
}
