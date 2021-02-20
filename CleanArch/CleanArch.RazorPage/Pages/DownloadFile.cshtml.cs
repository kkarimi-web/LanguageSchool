using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.RazorPage.Pages
{
    public class DownloadFileModel : PageModel
    {

        private IFileRepositoryService _fileRepositoryService;

        public DownloadFileModel(IFileRepositoryService fileRepositoryService)
        {
            _fileRepositoryService = fileRepositoryService;
        }

        public FileResult OnGet(string pathlocator)
        {
            vDocument d = _fileRepositoryService.DownloadFile(pathlocator.Replace('-', '/'));
            //
            if (d != null)
            {

                byte[] fileBytes = (byte[])d.file_stream; // from FileTable
                string fileName = d.name;
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
                return null;

        }
    }
}