using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Configurations
{
    public class CourseDocumentConfiguration : IEntityTypeConfiguration<CourseDocument>
    {
        public void Configure(EntityTypeBuilder<CourseDocument> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Ignore(c => c.IntroImage);
            builder.Ignore(c => c.SecondImage);
        }
    }
}
