using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Interfaces
{
    public interface IFileRepositoryService
    {
        string SaveFile(IFormFile formFile, string Path);
        void DeleteFile(string pathlocator, string RefrenceTable, string ColumnName);
        vDocument DownloadFile(string pathlocator);
    }
}
