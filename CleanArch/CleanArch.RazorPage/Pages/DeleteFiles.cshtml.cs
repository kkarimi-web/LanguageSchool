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
    public class DeleteFilesModel : PageModel
    {
        private IFileRepositoryService _fileRepositoryService;
        public DeleteFilesModel(IFileRepositoryService fileRepositoryService)
        {
            _fileRepositoryService = fileRepositoryService;
        }
        public void OnGet(string pathlocator, string RefrenceTable, string ColumnName)
        {
            //if (!string.IsNullOrEmpty(pathlocator))
            //{
            //    SqlParameter param1 = new SqlParameter("RefTable", System.Data.SqlDbType.VarChar, 100) { Value = RefrenceTable };// DBNull.Value };
            //    SqlParameter param2 = new SqlParameter("ColName", System.Data.SqlDbType.VarChar, 100) { Value = ColumnName };
            //    SqlParameter param3 = new SqlParameter("path_locator", System.Data.SqlDbType.VarChar, 4000) { Value = pathlocator.Replace('-', '/') };
            //    vDocument d = _ctx.vDocuments.
            //                         FromSqlRaw("EXECUTE dbo.DelDocument @RefTable,@ColName,@path_locator", param1, param2, param3)
            //                         .AsEnumerable().FirstOrDefault();               

            //}
            _fileRepositoryService.DeleteFile(pathlocator.Replace('-', '/'), RefrenceTable, ColumnName);
        }
    }
}