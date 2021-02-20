using CleanArch.Application.Interfaces;
using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Services
{
    public class FileRepositoryService : IFileRepositoryService
    {
        // private IFileRepository _fileRepository;
        private IUnitOfWork _unitOfWork;

        public FileRepositoryService(IUnitOfWork unitOfWork)//IFileRepository fileRepository)
        {
            // _fileRepository = fileRepository;
            _unitOfWork = unitOfWork;
        }

        public void DeleteFile(string pathlocator, string RefrenceTable, string ColumnName)
        {
            _unitOfWork.fileRepository.DeleteFile(pathlocator, RefrenceTable, ColumnName);
        }

        public vDocument DownloadFile(string pathlocator)
        {
            return _unitOfWork.fileRepository.DownloadFile(pathlocator);
        }

        public string SaveFile(IFormFile formFile, string Path)
        {
            return _unitOfWork.fileRepository.SaveFile(formFile,Path);
        }
    }
}
