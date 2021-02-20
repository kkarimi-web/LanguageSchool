using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(200)
                    ;
           // builder.Ignore(c => c.UploadFiles);
           // builder.Ignore(d => d.SecondUploadFiles);
        }
    }
}
