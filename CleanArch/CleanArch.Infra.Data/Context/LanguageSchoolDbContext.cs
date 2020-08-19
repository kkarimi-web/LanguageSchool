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
           // Database.SetInitializer<LanguageSchoolDbContext>(null);
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CourseConfiguration());
        }
    }
}
