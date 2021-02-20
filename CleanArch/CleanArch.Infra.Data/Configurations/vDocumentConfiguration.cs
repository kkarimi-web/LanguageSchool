using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Infra.Data.Configurations
{
    class vDocumentConfiguration: IEntityTypeConfiguration<vDocument>
    {     

        public void Configure(EntityTypeBuilder<vDocument> builder)
        {
            builder.HasKey(o => o.stream_Id);
        }
    }
}
