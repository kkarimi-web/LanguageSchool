using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Context
{
    public class LanguageSchoolDbContext : DbContext
    {

        public LanguageSchoolDbContext(DbContextOptions options) : base(options)
        {


        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseType> CourseType { get; set; }     
        public DbSet<vDocument> vDocuments { get; set; }
        public DbSet<CourseDocument> CourseDocument { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new CourseTypeConfiguration());           
            builder.ApplyConfiguration(new vDocumentConfiguration());
            builder.ApplyConfiguration(new CourseDocumentConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
