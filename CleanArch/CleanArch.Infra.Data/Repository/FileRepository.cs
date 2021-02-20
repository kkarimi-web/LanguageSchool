using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using CleanArch.Infra.Data.Infrastructure;

namespace CleanArch.Infra.Data.Repository
{
    public class FileRepository :Repository<vDocument>, IFileRepository
    {
      //  public LanguageSchoolDbContext _ctx;

        public FileRepository(LanguageSchoolDbContext ctx):base(ctx)
        {
          //  _ctx = ctx;
        }

        public void DeleteFile(string pathlocator, string RefrenceTable, string ColumnName)
        {
            if (!string.IsNullOrEmpty(pathlocator))
            {
                SqlParameter param1 = new SqlParameter("RefTable", System.Data.SqlDbType.VarChar, 100) { Value = RefrenceTable };// DBNull.Value };
                SqlParameter param2 = new SqlParameter("ColName", System.Data.SqlDbType.VarChar, 100) { Value = ColumnName };
                SqlParameter param3 = new SqlParameter("path_locator", System.Data.SqlDbType.VarChar, 4000) { Value = pathlocator };
                vDocument d = _context.vDocuments.
                                     FromSqlRaw("EXECUTE dbo.DelDocument @RefTable,@ColName,@path_locator", param1, param2, param3)
                                     .AsEnumerable().FirstOrDefault();
            }
        }

        public vDocument DownloadFile(string pathlocator)
        {
            if (!string.IsNullOrEmpty(pathlocator))
            {
                SqlParameter param1 = new SqlParameter("path_locator", System.Data.SqlDbType.VarChar, 4000) { Value = pathlocator };
                vDocument d = _context.vDocuments.
                                     FromSqlRaw("EXECUTE dbo.GetDocument @path_locator", param1)
                                     .AsEnumerable().FirstOrDefault();
                return d;
            }
            else
                return null;
        }
        public string SaveFile(IFormFile formFile, string Path)
        {
            if (formFile == null)
                throw new ArgumentNullException(nameof(formFile));

            string filename = ContentDispositionHeaderValue.Parse(formFile.ContentDisposition).FileName.ToString().Trim('"');
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentNullException(nameof(filename));

            string filepath_locator = string.Empty;
            long? UploadedFileSize = formFile.Length;
            using (Stream stream = formFile.OpenReadStream())
            {
                BinaryReader reader = new BinaryReader(stream);
                byte[] bytes = reader.ReadBytes((int)UploadedFileSize);
                //
                SqlParameter param1 = new SqlParameter("relativePath", System.Data.SqlDbType.VarChar, 255) { Value = Path };// DBNull.Value };
                SqlParameter param2 = new SqlParameter("name", System.Data.SqlDbType.VarChar, 255) { Value = Guid.NewGuid()+"_"+ filename };
                SqlParameter param3 = new SqlParameter("stream", System.Data.SqlDbType.VarBinary) { Value = bytes };
                SqlParameter param4 = new SqlParameter("path_locator", System.Data.SqlDbType.VarChar, 4000) { Value = DBNull.Value };
                filepath_locator = _context.vDocuments.
                                     FromSqlRaw("EXECUTE dbo.AddDocument @relativePath,@name,@stream,@path_locator", param1, param2, param3, param4)
                                     .AsEnumerable().FirstOrDefault().path_locator;

                return filepath_locator;
            }
        }
    }
}
