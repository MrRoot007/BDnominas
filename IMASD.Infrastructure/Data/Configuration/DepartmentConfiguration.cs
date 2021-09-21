using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nomina2018.Core.Entities;
using System;
using System.Collections.Generic;

#nullable disable

namespace Nomina2018.Infrastructure.Data
{
    public partial class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.ToTable("Department");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("iIdDepartment");

            builder.Property(e => e.SName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sName");

        }
    }
}
